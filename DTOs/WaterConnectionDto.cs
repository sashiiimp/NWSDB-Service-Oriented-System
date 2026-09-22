namespace NWSDB.Server.DTOs;

public class WaterConnectionDto
{
    public int ConnectionId { get; set; }
    public int CustomerId { get; set; }
    public string ConnectionNumber { get; set; } = string.Empty;
    public string ConnectionAddress { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}
