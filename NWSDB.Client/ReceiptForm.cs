using NWSDB.Client.Helpers;
using NWSDB.Client.Models;

namespace NWSDB.Client
{
    // Read-only view of a receipt already fetched from GET /api/payments/{paymentId}/receipt.
    public partial class ReceiptForm : Form
    {
        public ReceiptForm(PaymentReceiptDto receipt, CustomerDto customer)
        {
            InitializeComponent();

            lblReceiptNumber.Text = receipt.ReceiptNumber;
            lblIssuedDate.Text = UiHelper.FormatDateTime(receipt.IssuedDate);
            lblCustomerName.Text = customer.FullName;
            lblAccountNumber.Text = customer.AccountNumber;
            lblPaymentId.Text = receipt.PaymentId.ToString();
            lblBillNumber.Text = UiHelper.FormatBillNumber(receipt.BillId);
            lblAmountPaid.Text = UiHelper.FormatCurrency(receipt.AmountPaid);
            lblPaymentDate.Text = UiHelper.FormatDateTime(receipt.PaymentDate);
            lblPaymentMethod.Text = UiHelper.SplitWords(receipt.PaymentMethod);
            lblSource.Text = UiHelper.SplitWords(receipt.Source);
            lblTransactionReference.Text = receipt.TransactionReference;
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
