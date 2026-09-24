using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using NWSDB.Client.Models;

namespace NWSDB.Client.Services;

// All communication with NWSDB.Server goes through this class using REST/JSON.
// The client has no database access and no reference to the server project.
public class ApiService : IDisposable
{
    // Matches ASP.NET Core's default JSON settings (camelCase, case-insensitive).
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    private readonly HttpClient _httpClient;

    public ApiService()
        : this(ApiSettings.BaseUrl)
    {
    }

    public ApiService(string baseUrl)
    {
        // One HttpClient for the lifetime of the application, as recommended,
        // rather than creating a new one per request.
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseUrl),
            Timeout = ApiSettings.RequestTimeout
        };
        _httpClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");
    }

    // ---- Customers ----

    public Task<CustomerDto> GetCustomerByAccountNumberAsync(string accountNumber) =>
        GetAsync<CustomerDto>($"api/customers/account/{Uri.EscapeDataString(accountNumber)}");

    // ---- Connections ----

    public Task<List<WaterConnectionDto>> GetConnectionsAsync(int customerId) =>
        GetAsync<List<WaterConnectionDto>>($"api/connections/customer/{customerId}");

    // ---- Usage ----

    public Task<List<MeterReadingDto>> GetCurrentUsageAsync(int customerId) =>
        GetAsync<List<MeterReadingDto>>($"api/usage/{customerId}/current");

    public Task<List<MeterReadingDto>> GetUsageHistoryAsync(int customerId) =>
        GetAsync<List<MeterReadingDto>>($"api/usage/{customerId}/history");

    // ---- Bills ----

    public Task<BillDto> GetCurrentBillAsync(int customerId) =>
        GetAsync<BillDto>($"api/bills/{customerId}/current");

    public Task<List<BillDto>> GetBillHistoryAsync(int customerId) =>
        GetAsync<List<BillDto>>($"api/bills/{customerId}/history");

    public Task<BillDto> GetBillDetailsAsync(int billId) =>
        GetAsync<BillDto>($"api/bills/details/{billId}");

    // ---- Payments ----

    public Task<PaymentDto> CreatePaymentAsync(CreatePaymentRequestDto request) =>
        PostAsync<CreatePaymentRequestDto, PaymentDto>("api/payments", request);

    public Task<List<PaymentDto>> GetPaymentHistoryAsync(int customerId) =>
        GetAsync<List<PaymentDto>>($"api/payments/{customerId}/history");

    public Task<PaymentReceiptDto> GetReceiptAsync(int paymentId) =>
        GetAsync<PaymentReceiptDto>($"api/payments/{paymentId}/receipt");

    // ---- Admin ----

    public Task<AdminLoginResponseDto> AdminLoginAsync(AdminLoginRequestDto request) =>
        PostAsync<AdminLoginRequestDto, AdminLoginResponseDto>("api/admin/login", request);

    // The admin endpoints require "Authorization: Bearer <token>". The token is
    // attached to every request until the admin logs out.
    public void SetAdminToken(string token) =>
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    public void ClearAdminToken() =>
        _httpClient.DefaultRequestHeaders.Authorization = null;

    public Task<List<AdminConnectionDto>> GetAdminConnectionsAsync() =>
        GetAsync<List<AdminConnectionDto>>("api/admin/connections");

    public Task<List<AdminCustomerDto>> GetAdminCustomersAsync() =>
        GetAsync<List<AdminCustomerDto>>("api/admin/customers");

    public Task<MeterReadingDto> RecordMeterReadingAsync(CreateMeterReadingRequestDto request) =>
        PostAsync<CreateMeterReadingRequestDto, MeterReadingDto>("api/admin/meter-readings", request);

    public Task<BillDto> GenerateBillAsync(GenerateBillRequestDto request) =>
        PostAsync<GenerateBillRequestDto, BillDto>("api/admin/bills", request);

    // ---- HTTP helpers ----

    private Task<T> GetAsync<T>(string relativeUrl) =>
        SendAsync<T>(() => _httpClient.GetAsync(relativeUrl));

    private Task<TResponse> PostAsync<TRequest, TResponse>(string relativeUrl, TRequest body) =>
        SendAsync<TResponse>(() => _httpClient.PostAsJsonAsync(relativeUrl, body, JsonOptions));

    private async Task<T> SendAsync<T>(Func<Task<HttpResponseMessage>> send)
    {
        HttpResponseMessage response;
        try
        {
            response = await send();
        }
        catch (HttpRequestException ex)
        {
            throw new ApiException(null,
                $"Unable to connect to the NWSDB service at {_httpClient.BaseAddress}.\n" +
                "Please make sure NWSDB.Server is running and try again.", ex);
        }
        catch (TaskCanceledException ex)
        {
            throw new ApiException(null,
                "The NWSDB service did not respond in time. Please try again.", ex);
        }

        using (response)
        {
            // 200 OK and 201 Created both land here.
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<T>(JsonOptions);
                return result ?? throw new ApiException(response.StatusCode,
                    "The NWSDB service returned an empty response.");
            }

            var message = await ReadErrorMessageAsync(response);
            throw new ApiException(response.StatusCode, message);
        }
    }

    // Turns an error response into a readable message, preferring the text the
    // server sent (e.g. "Payment amount 9000.00 exceeds the outstanding balance...").
    private static async Task<string> ReadErrorMessageAsync(HttpResponseMessage response)
    {
        string? serverMessage = null;
        try
        {
            var error = await response.Content.ReadFromJsonAsync<ApiErrorResponse>(JsonOptions);
            if (!string.IsNullOrWhiteSpace(error?.Error))
            {
                serverMessage = error.Error;
            }
            else if (error?.Errors is { Count: > 0 })
            {
                serverMessage = string.Join(Environment.NewLine, error.Errors.Values.SelectMany(v => v));
            }
            else if (!string.IsNullOrWhiteSpace(error?.Title))
            {
                serverMessage = error.Title;
            }
        }
        catch (Exception ex) when (ex is JsonException or NotSupportedException)
        {
            // Body was not JSON - fall back to a generic message below.
        }

        if (serverMessage is not null)
        {
            return serverMessage;
        }

        return response.StatusCode switch
        {
            HttpStatusCode.BadRequest => "The request was invalid.",
            HttpStatusCode.Unauthorized => "You are not authorised to perform this action.",
            HttpStatusCode.NotFound => "The requested record was not found.",
            HttpStatusCode.Conflict => "The request conflicts with the current state of the record.",
            _ => $"The NWSDB service returned an error ({(int)response.StatusCode} {response.ReasonPhrase})."
        };
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
