using System.ComponentModel.DataAnnotations;

namespace NWSDB.Server.Models;

public class WaterConnection
{
    public int ConnectionId { get; set; }

    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    [Required, MaxLength(20)]
    public string ConnectionNumber { get; set; } = string.Empty;

    [Required, MaxLength(250)]
    public string ConnectionAddress { get; set; } = string.Empty;

    public ConnectionStatus Status { get; set; } = ConnectionStatus.Active;

    public ICollection<MeterReading> MeterReadings { get; set; } = new List<MeterReading>();
    public ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
