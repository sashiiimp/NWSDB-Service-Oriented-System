namespace NWSDB.Client.Models;

// Error body produced by the server's ExceptionHandlingMiddleware and
// ApiKeyAuthMiddleware: { "status": 404, "error": "..." }.
// Title/Errors cover ASP.NET Core's automatic model-validation response
// (ValidationProblemDetails), which is returned for malformed request bodies.
public class ApiErrorResponse
{
    public int Status { get; set; }
    public string? Error { get; set; }
    public string? Title { get; set; }
    public Dictionary<string, string[]>? Errors { get; set; }
}
