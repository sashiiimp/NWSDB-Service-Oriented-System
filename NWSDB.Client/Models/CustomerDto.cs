namespace NWSDB.Client.Models;

// Client-side copy of the JSON returned by /api/customers. Kept separate from the
// server's DTO classes so the client depends only on the REST contract.
public class CustomerDto
{
    public int CustomerId { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}
