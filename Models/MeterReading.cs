namespace NWSDB.Server.Models;

public class MeterReading
{
    public int ReadingId { get; set; }

    public int ConnectionId { get; set; }
    public WaterConnection? Connection { get; set; }

    public DateTime ReadingDate { get; set; }

    public decimal PreviousReading { get; set; }
    public decimal CurrentReading { get; set; }
    public decimal UnitsConsumed { get; set; }
}
