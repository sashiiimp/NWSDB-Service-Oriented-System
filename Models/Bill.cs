namespace NWSDB.Server.Models;

public class Bill
{
    public int BillId { get; set; }

    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public int ConnectionId { get; set; }
    public WaterConnection? Connection { get; set; }

    public DateTime BillingPeriodStart { get; set; }
    public DateTime BillingPeriodEnd { get; set; }

    public decimal UnitsConsumed { get; set; }
    public decimal Amount { get; set; }

    public DateTime IssuedDate { get; set; }
    public DateTime DueDate { get; set; }

    public BillStatus Status { get; set; } = BillStatus.Unpaid;

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
