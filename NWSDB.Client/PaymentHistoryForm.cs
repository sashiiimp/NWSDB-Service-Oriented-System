using NWSDB.Client.Helpers;
using NWSDB.Client.Models;
using NWSDB.Client.Services;

namespace NWSDB.Client
{
    // Lists previous payments; a receipt can be opened for the selected payment
    // via GET /api/payments/{paymentId}/receipt.
    public partial class PaymentHistoryForm : Form
    {
        private readonly ApiService _apiService;
        private readonly CustomerDto _customer;

        public PaymentHistoryForm(ApiService apiService, CustomerDto customer)
        {
            InitializeComponent();
            UiHelper.ApplyGridStyle(dgvPaymentHistory);
            _apiService = apiService;
            _customer = customer;
            lblCustomer.Text = UiHelper.DescribeCustomer(customer);
            btnViewReceipt.Enabled = false;
        }

        private async void PaymentHistoryForm_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                var payments = await _apiService.GetPaymentHistoryAsync(_customer.CustomerId);

                dgvPaymentHistory.DataSource = payments
                    .Select(p => new PaymentRow(
                        p.PaymentId,
                        UiHelper.FormatDateTime(p.PaymentDate),
                        UiHelper.FormatBillNumber(p.BillId),
                        UiHelper.FormatCurrency(p.AmountPaid),
                        UiHelper.SplitWords(p.PaymentMethod),
                        UiHelper.SplitWords(p.Source),
                        p.TransactionReference))
                    .ToList();

                btnViewReceipt.Enabled = payments.Count > 0;
                lblSummary.Text = payments.Count == 0
                    ? "No payments have been made on this account."
                    : $"{payments.Count} payment(s)   |   Total paid: {UiHelper.FormatCurrency(payments.Sum(p => p.AmountPaid))}" +
                      "   |   Select a payment and click View Receipt (or double-click a row).";
            }
            catch (ApiException ex)
            {
                lblSummary.Text = "Payment history could not be loaded.";
                UiHelper.ShowApiError(this, ex, "load your payment history");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void btnViewReceipt_Click(object sender, EventArgs e) => await ViewSelectedReceiptAsync();

        private async void dgvPaymentHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                await ViewSelectedReceiptAsync();
            }
        }

        private async Task ViewSelectedReceiptAsync()
        {
            if (dgvPaymentHistory.CurrentRow?.DataBoundItem is not PaymentRow row)
            {
                UiHelper.ShowValidation(this, "Please select a payment first.");
                return;
            }

            btnViewReceipt.Enabled = false;
            Cursor = Cursors.WaitCursor;
            PaymentReceiptDto receipt;
            try
            {
                receipt = await _apiService.GetReceiptAsync(row.PaymentId);
            }
            catch (ApiException ex)
            {
                UiHelper.ShowApiError(this, ex, $"load the receipt for payment {row.PaymentId}");
                return;
            }
            finally
            {
                btnViewReceipt.Enabled = true;
                Cursor = Cursors.Default;
            }

            using var receiptForm = new ReceiptForm(receipt, _customer);
            receiptForm.ShowDialog(this);
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        internal sealed record PaymentRow(
            int PaymentId, string PaymentDate, string BillNumber, string AmountPaid,
            string PaymentMethod, string Source, string TransactionReference);
    }
}
