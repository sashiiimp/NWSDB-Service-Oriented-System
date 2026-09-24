namespace NWSDB.Client.Models;

public class AdminLoginResponseDto
{
    public int AdminId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAtUtc { get; set; }
}
