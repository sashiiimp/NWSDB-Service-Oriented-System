namespace NWSDB.Client.Models;

public class AdminConnectionDto
{
    public int ConnectionId { get; set; }
    public string ConnectionNumber { get; set; } = string.Empty;
    public string ConnectionAddress { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;

    public int CustomerId { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;

    public int? LatestReadingId { get; set; }
    public DateTime? LatestReadingDate { get; set; }
    public decimal? LatestReadingValue { get; set; }
}
