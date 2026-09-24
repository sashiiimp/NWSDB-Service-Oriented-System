using System.Globalization;
using System.Net;
using NWSDB.Client.Helpers;
using NWSDB.Client.Models;
using NWSDB.Client.Services;

namespace NWSDB.Client
{
    // Pays an outstanding bill through POST /api/payments. The client only does
    // basic input checks; the server remains responsible for the business rules
    // (amount > 0, not more than the outstanding balance, bill ownership, etc.).
    public partial class MakePaymentForm : Form
    {
        // Values accepted by the server's PaymentMethod field.
        private static readonly PaymentMethodOption[] PaymentMethods =
        {
            new("Card", "Card"),
            new("OnlineBanking", "Online Banking"),
            new("BankTransfer", "Bank Transfer"),
            new("Cash", "Cash"),
            new("Cheque", "Cheque")
        };

        private readonly ApiService _apiService;
        private readonly CustomerDto _customer;
        private readonly IReadOnlyList<WaterConnectionDto> _connections;

        public MakePaymentForm(ApiService apiService, CustomerDto customer, IReadOnlyList<WaterConnectionDto> connections)
        {
            InitializeComponent();
            _apiService = apiService;
            _customer = customer;
            _connections = connections;
            lblCustomer.Text = UiHelper.DescribeCustomer(customer);

            cmbPaymentMethod.Items.AddRange(PaymentMethods);
            cmbPaymentMethod.SelectedIndex = 0;
        }

        private async void MakePaymentForm_Load(object sender, EventArgs e)
        {
            await LoadOutstandingBillsAsync(preferredBillId: null);
        }

        // Lists every bill with a balance still owing, pre-selecting the customer's
        // current bill (GET /api/bills/{id}/current) where possible.
        private async Task LoadOutstandingBillsAsync(int? preferredBillId)
        {
            SetBusy(true);
            cmbBill.Items.Clear();
            try
            {
                var bills = await _apiService.GetBillHistoryAsync(_customer.CustomerId);
                var outstanding = bills
                    .Where(b => b.OutstandingAmount > 0)
                    .OrderBy(b => b.DueDate)
                    .ToList();

                if (outstanding.Count == 0)
                {
                    ClearBillDetails();
                    grpBill.Text = "All bills are fully paid - nothing to pay.";
                    btnPay.Enabled = false;
                    return;
                }

                preferredBillId ??= (await _apiService.GetCurrentBillAsync(_customer.CustomerId)).BillId;

                foreach (var bill in outstanding)
                {
                    cmbBill.Items.Add(new BillOption(bill, UiHelper.DescribeConnection(_connections, bill.ConnectionId)));
                }

                var preferredIndex = outstanding.FindIndex(b => b.BillId == preferredBillId);
                cmbBill.SelectedIndex = preferredIndex >= 0 ? preferredIndex : 0;
                grpBill.Text = "Selected Bill";
                btnPay.Enabled = true;
            }
            catch (ApiException ex)
            {
                btnPay.Enabled = false;
                UiHelper.ShowApiError(this, ex, "load your outstanding bills");
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void cmbBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBill.SelectedItem is not BillOption option)
            {
                return;
            }

            var bill = option.Bill;
            lblBillingPeriod.Text = UiHelper.FormatPeriod(bill.BillingPeriodStart, bill.BillingPeriodEnd);
            lblAmount.Text = UiHelper.FormatCurrency(bill.Amount);
            lblAmountPaid.Text = UiHelper.FormatCurrency(bill.AmountPaid);
            lblOutstanding.Text = UiHelper.FormatCurrency(bill.OutstandingAmount);
            lblDueDate.Text = UiHelper.FormatDate(bill.DueDate);
            txtAmount.Text = bill.OutstandingAmount.ToString("0.00", CultureInfo.InvariantCulture);
        }

        private async void btnPay_Click(object sender, EventArgs e)
        {
            if (cmbBill.SelectedItem is not BillOption option)
            {
                UiHelper.ShowValidation(this, "Please select the bill you want to pay.");
                return;
            }

            if (!TryParseAmount(txtAmount.Text, out var amount))
            {
                UiHelper.ShowValidation(this, "Please enter a valid payment amount, for example 1500.00.");
                txtAmount.Focus();
                return;
            }

            if (amount <= 0)
            {
                UiHelper.ShowValidation(this, "The payment amount must be greater than zero.");
                txtAmount.Focus();
                return;
            }

            if (cmbPaymentMethod.SelectedItem is not PaymentMethodOption method)
            {
                UiHelper.ShowValidation(this, "Please select a payment method.");
                return;
            }

            var confirm = MessageBox.Show(this,
                $"Pay {UiHelper.FormatCurrency(amount)} towards bill {UiHelper.FormatBillNumber(option.Bill.BillId)} using {method.Display}?",
                "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            var request = new CreatePaymentRequestDto
            {
                BillId = option.Bill.BillId,
                CustomerId = _customer.CustomerId,
                AmountPaid = amount,
                PaymentMethod = method.Value
            };

            PaymentDto payment;
            SetBusy(true);
            try
            {
                payment = await _apiService.CreatePaymentAsync(request);
            }
            catch (ApiException ex) when (ex.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.NotFound or HttpStatusCode.Conflict)
            {
                // Business-rule rejection from the server (e.g. amount exceeds the outstanding balance).
                MessageBox.Show(this, ex.Message, "Payment Rejected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (ApiException ex)
            {
                UiHelper.ShowApiError(this, ex, "submit your payment");
                return;
            }
            finally
            {
                SetBusy(false);
            }

            await ShowReceiptAsync(payment);
            await LoadOutstandingBillsAsync(option.Bill.BillId);
        }

        private async Task ShowReceiptAsync(PaymentDto payment)
        {
            try
            {
                var receipt = await _apiService.GetReceiptAsync(payment.PaymentId);
                using var receiptForm = new ReceiptForm(receipt, _customer);
                receiptForm.ShowDialog(this);
            }
            catch (ApiException ex)
            {
                // The payment itself succeeded, so still show its reference.
                MessageBox.Show(this,
                    $"Payment successful.\n\nTransaction reference: {payment.TransactionReference}\n\n" +
                    $"The receipt could not be loaded: {ex.Message}",
                    "Payment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static bool TryParseAmount(string text, out decimal amount)
        {
            text = text.Trim();
            return decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out amount)
                || decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out amount);
        }

        private void ClearBillDetails()
        {
            lblBillingPeriod.Text = lblAmount.Text = lblAmountPaid.Text = lblOutstanding.Text = lblDueDate.Text = "-";
            txtAmount.Clear();
        }

        private void SetBusy(bool busy)
        {
            btnPay.Enabled = !busy && cmbBill.Items.Count > 0;
            btnPay.Text = busy ? "Please wait..." : "Pay Now";
            cmbBill.Enabled = !busy;
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private sealed record PaymentMethodOption(string Value, string Display)
        {
            public override string ToString() => Display;
        }

        private sealed record BillOption(BillDto Bill, string ConnectionNumber)
        {
            public override string ToString() =>
                $"Bill {UiHelper.FormatBillNumber(Bill.BillId)}  |  {ConnectionNumber}  |  Due {UiHelper.FormatDate(Bill.DueDate)}";
        }
    }
}
