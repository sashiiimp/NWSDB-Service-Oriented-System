namespace NWSDB.Server.Models;

public class PaymentReceipt
{
    public int ReceiptId { get; set; }

    public int PaymentId { get; set; }
    public Payment? Payment { get; set; }

    public string ReceiptNumber { get; set; } = string.Empty;
    public DateTime IssuedDate { get; set; }
}
