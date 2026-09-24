namespace NWSDB.Client.Models;

public class PaymentDto
{
    public int PaymentId { get; set; }
    public int BillId { get; set; }
    public int CustomerId { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string TransactionReference { get; set; } = string.Empty;
}
