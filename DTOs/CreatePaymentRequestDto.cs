using System.ComponentModel.DataAnnotations;

namespace NWSDB.Server.DTOs;

public class CreatePaymentRequestDto
{
    [Required]
    public int BillId { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "AmountPaid must be greater than zero.")]
    public decimal AmountPaid { get; set; }

    [Required]
    public string PaymentMethod { get; set; } = string.Empty;
}
