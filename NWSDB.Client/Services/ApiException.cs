using System.Net;

namespace NWSDB.Client.Services;

// Raised by ApiService for any failed call so forms only need one catch block.
// StatusCode is null when the server could not be reached at all.
public class ApiException : Exception
{
    public ApiException(HttpStatusCode? statusCode, string message, Exception? innerException = null)
        : base(message, innerException)
    {
        StatusCode = statusCode;
    }

    public HttpStatusCode? StatusCode { get; }

    public bool IsConnectionError => StatusCode is null;
}
