using System.ComponentModel.DataAnnotations;

namespace NWSDB.Server.DTOs;

public class GenerateBillRequestDto
{
    [Required]
    public int ReadingId { get; set; }
}
