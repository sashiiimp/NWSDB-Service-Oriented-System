using System.ComponentModel.DataAnnotations;

namespace NWSDB.Server.DTOs;

public class CreateMeterReadingRequestDto
{
    [Required]
    public int ConnectionId { get; set; }

    [Required]
    public DateTime ReadingDate { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "CurrentReading cannot be negative.")]
    public decimal CurrentReading { get; set; }

    // Only used for a connection's first ever reading (the meter's starting value).
    // For every later reading the server takes PreviousReading from the latest
    // recorded reading, so it can't be mistyped. Defaults to 0 when omitted.
    [Range(0, double.MaxValue, ErrorMessage = "PreviousReading cannot be negative.")]
    public decimal? PreviousReading { get; set; }
}
