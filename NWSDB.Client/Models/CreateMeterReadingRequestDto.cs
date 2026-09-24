namespace NWSDB.Client.Models;

// Request body for POST /api/admin/meter-readings.
public class CreateMeterReadingRequestDto
{
    public int ConnectionId { get; set; }
    public DateTime ReadingDate { get; set; }
    public decimal CurrentReading { get; set; }

    // Only sent for a connection's first reading; otherwise the server uses the latest reading.
    public decimal? PreviousReading { get; set; }
}
