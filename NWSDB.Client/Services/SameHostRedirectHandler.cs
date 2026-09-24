using System.Net;

namespace NWSDB.Client.Services;

// HttpClient's built-in redirect handling always removes the Authorization
// header. When NWSDB.Server runs with its "https" launch profile it redirects
// http://localhost:5074 to https://localhost:7058, so every admin request
// arrived without its JWT and was rejected with 401. This handler follows
// redirects itself and keeps the request headers, but only while the redirect
// stays on the same host, so the token is never sent anywhere else.
public sealed class SameHostRedirectHandler : DelegatingHandler
{
    private const int MaxRedirects = 5;

    public SameHostRedirectHandler()
        : base(new HttpClientHandler { AllowAutoRedirect = false })
    {
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);

        for (var redirects = 0; redirects < MaxRedirects && IsRedirect(response.StatusCode); redirects++)
        {
            var location = response.Headers.Location;
            if (location is null || request.RequestUri is null)
            {
                break;
            }

            var target = location.IsAbsoluteUri ? location : new Uri(request.RequestUri, location);
            if (!string.Equals(target.Host, request.RequestUri.Host, StringComparison.OrdinalIgnoreCase))
            {
                // Different host: return the redirect rather than forward credentials.
                break;
            }

            // 307/308 must repeat the same method and body; 301/302/303 become a GET,
            // matching HttpClient's own redirect behaviour.
            var keepMethod = response.StatusCode is HttpStatusCode.TemporaryRedirect or HttpStatusCode.PermanentRedirect
                             || request.Method == HttpMethod.Get || request.Method == HttpMethod.Head;

            var next = new HttpRequestMessage(keepMethod ? request.Method : HttpMethod.Get, target)
            {
                Content = keepMethod ? request.Content : null,
                Version = request.Version
            };
            foreach (var header in request.Headers)
            {
                next.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            response.Dispose();
            request = next;
            response = await base.SendAsync(request, cancellationToken);
        }

        return response;
    }

    private static bool IsRedirect(HttpStatusCode statusCode) => statusCode is
        HttpStatusCode.MovedPermanently or HttpStatusCode.Found or HttpStatusCode.SeeOther or
        HttpStatusCode.TemporaryRedirect or HttpStatusCode.PermanentRedirect;
}
