using NWSDB.Client.Helpers;
using NWSDB.Client.Models;
using NWSDB.Client.Services;

namespace NWSDB.Client
{
    public partial class BillHistoryForm : Form
    {
        private readonly ApiService _apiService;
        private readonly CustomerDto _customer;
        private readonly IReadOnlyList<WaterConnectionDto> _connections;

        public BillHistoryForm(ApiService apiService, CustomerDto customer, IReadOnlyList<WaterConnectionDto> connections)
        {
            InitializeComponent();
            UiHelper.ApplyGridStyle(dgvBillHistory);
            colStatus.DefaultCellStyle.Font = new Font(dgvBillHistory.Font, FontStyle.Bold);
            _apiService = apiService;
            _customer = customer;
            _connections = connections;
            lblCustomer.Text = UiHelper.DescribeCustomer(customer);
        }

        private async void BillHistoryForm_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                var bills = await _apiService.GetBillHistoryAsync(_customer.CustomerId);

                dgvBillHistory.DataSource = bills
                    .Select(b => new BillRow(
                        UiHelper.FormatBillNumber(b.BillId),
                        UiHelper.DescribeConnection(_connections, b.ConnectionId),
                        UiHelper.FormatPeriod(b.BillingPeriodStart, b.BillingPeriodEnd),
                        b.UnitsConsumed.ToString("N2"),
                        UiHelper.FormatCurrency(b.Amount),
                        UiHelper.FormatCurrency(b.AmountPaid),
                        UiHelper.FormatCurrency(b.OutstandingAmount),
                        UiHelper.FormatDate(b.IssuedDate),
                        UiHelper.FormatDate(b.DueDate),
                        UiHelper.SplitWords(b.Status),
                        b.Status))
                    .ToList();

                lblSummary.Text = bills.Count == 0
                    ? "No bills have been issued for this account."
                    : $"{bills.Count} bill(s)   |   Total outstanding: {UiHelper.FormatCurrency(bills.Sum(b => b.OutstandingAmount))}";
            }
            catch (ApiException ex)
            {
                lblSummary.Text = "Bill history could not be loaded.";
                UiHelper.ShowApiError(this, ex, "load your bill history");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // Colour the Status column so paid / partially paid / overdue bills are easy to spot.
        private void dgvBillHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvBillHistory.Columns[e.ColumnIndex] != colStatus || e.CellStyle is null)
            {
                return;
            }

            if (dgvBillHistory.Rows[e.RowIndex].DataBoundItem is BillRow row)
            {
                e.CellStyle.ForeColor = UiHelper.GetStatusColor(row.StatusCode);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        // Display-ready row for the grid. StatusCode keeps the raw API value for colouring.
        internal sealed record BillRow(
            string BillNumber, string Connection, string BillingPeriod, string UnitsConsumed, string Amount,
            string AmountPaid, string Outstanding, string IssuedDate, string DueDate, string Status, string StatusCode);
    }
}
