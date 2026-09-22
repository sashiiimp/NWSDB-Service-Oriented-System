using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using NWSDB.Server.Data;
using NWSDB.Server.Models;

namespace NWSDB.Server.Middleware;

// Applied only to /api/partner/** routes (see Program.cs). Validates the
// X-Api-Key header against ThirdPartyPartner records and, on success, stashes
// the matched partner on HttpContext.Items so controllers can read it back.
public class ApiKeyAuthMiddleware
{
    private const string ApiKeyHeaderName = "X-Api-Key";
    public const string PartnerContextKey = "Partner";

    private readonly RequestDelegate _next;

    public ApiKeyAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, NwsdbDbContext dbContext)
    {
        if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKeyValues) ||
            string.IsNullOrWhiteSpace(apiKeyValues))
        {
            await Reject(context, "Missing X-Api-Key header.");
            return;
        }

        var apiKey = apiKeyValues.ToString();

        var partner = await dbContext.ThirdPartyPartners
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.ApiKey == apiKey);

        if (partner is null || partner.Status != PartnerStatus.Active)
        {
            await Reject(context, "Invalid or inactive API key.");
            return;
        }

        context.Items[PartnerContextKey] = partner;
        await _next(context);
    }

    private static async Task Reject(HttpContext context, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        var payload = JsonSerializer.Serialize(new { status = 401, error = message });
        await context.Response.WriteAsync(payload);
    }
}
