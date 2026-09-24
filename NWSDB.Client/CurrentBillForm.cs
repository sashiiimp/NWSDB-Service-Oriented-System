using NWSDB.Client.Helpers;
using NWSDB.Client.Models;
using NWSDB.Client.Services;

namespace NWSDB.Client
{
    // Shows the bill returned by GET /api/bills/{customerId}/current (the latest
    // outstanding bill, or the latest bill if everything has been paid).
    public partial class CurrentBillForm : Form
    {
        private readonly ApiService _apiService;
        private readonly CustomerDto _customer;
        private readonly IReadOnlyList<WaterConnectionDto> _connections;

        public CurrentBillForm(ApiService apiService, CustomerDto customer, IReadOnlyList<WaterConnectionDto> connections)
        {
            InitializeComponent();
            _apiService = apiService;
            _customer = customer;
            _connections = connections;
            lblCustomer.Text = UiHelper.DescribeCustomer(customer);
        }

        private async void CurrentBillForm_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                var bill = await _apiService.GetCurrentBillAsync(_customer.CustomerId);
                ShowBill(bill);
            }
            catch (ApiException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                grpBill.Text = "No bills have been issued for this account yet.";
            }
            catch (ApiException ex)
            {
                UiHelper.ShowApiError(this, ex, "load your current bill");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ShowBill(BillDto bill)
        {
            lblBillNumber.Text = UiHelper.FormatBillNumber(bill.BillId);
            lblConnection.Text = UiHelper.DescribeConnection(_connections, bill.ConnectionId);
            lblBillingPeriod.Text = UiHelper.FormatPeriod(bill.BillingPeriodStart, bill.BillingPeriodEnd);
            lblUnitsConsumed.Text = UiHelper.FormatUnits(bill.UnitsConsumed);
            lblAmount.Text = UiHelper.FormatCurrency(bill.Amount);
            lblAmountPaid.Text = UiHelper.FormatCurrency(bill.AmountPaid);
            lblOutstanding.Text = UiHelper.FormatCurrency(bill.OutstandingAmount);
            lblIssuedDate.Text = UiHelper.FormatDate(bill.IssuedDate);
            lblDueDate.Text = UiHelper.FormatDate(bill.DueDate);
            lblStatus.Text = UiHelper.SplitWords(bill.Status);
            lblStatus.ForeColor = UiHelper.GetStatusColor(bill.Status);
            lblOutstanding.ForeColor = bill.OutstandingAmount > 0 ? UiHelper.GetStatusColor("Overdue") : UiHelper.GetStatusColor("Paid");
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
