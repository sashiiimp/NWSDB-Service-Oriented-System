namespace NWSDB.Server.DTOs;

public class AdminCustomerDto
{
    public int CustomerId { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public List<WaterConnectionDto> Connections { get; set; } = new();
}
