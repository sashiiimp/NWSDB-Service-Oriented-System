namespace NWSDB.Client.Models;

// Request body for POST /api/admin/login.
public class AdminLoginRequestDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
