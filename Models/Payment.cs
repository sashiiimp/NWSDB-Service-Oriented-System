namespace NWSDB.Server.Models;

public class Payment
{
    public int PaymentId { get; set; }

    public int BillId { get; set; }
    public Bill? Bill { get; set; }

    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public decimal AmountPaid { get; set; }
    public DateTime PaymentDate { get; set; }

    public PaymentMethod PaymentMethod { get; set; }
    public PaymentSource Source { get; set; }

    public string TransactionReference { get; set; } = string.Empty;

    public PaymentReceipt? Receipt { get; set; }
}
