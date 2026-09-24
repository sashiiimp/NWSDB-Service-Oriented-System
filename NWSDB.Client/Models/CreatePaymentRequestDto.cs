namespace NWSDB.Client.Models;

// Request body for POST /api/payments.
public class CreatePaymentRequestDto
{
    public int BillId { get; set; }
    public int CustomerId { get; set; }
    public decimal AmountPaid { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
}
