namespace NWSDB.Server.DTOs;

public class AdminLoginResponseDto
{
    public int AdminId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;

    // JWT to send as "Authorization: Bearer <token>" on the other /api/admin endpoints.
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAtUtc { get; set; }
}
