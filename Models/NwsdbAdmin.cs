namespace NWSDB.Server.Models;

// Not wired to any endpoint in this prototype (no admin login flow was in scope).
// Included so the schema matches the case study; a future login endpoint could
// authenticate against this table using BCrypt.Verify(password, PasswordHash).
public class NwsdbAdmin
{
    public int AdminId { get; set; }

    public string FullName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;

    // Hashed with BCrypt - never store plain-text passwords.
    public string PasswordHash { get; set; } = string.Empty;
}
