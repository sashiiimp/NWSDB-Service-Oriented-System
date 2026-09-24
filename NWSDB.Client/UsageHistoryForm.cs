using NWSDB.Client.Helpers;
using NWSDB.Client.Models;
using NWSDB.Client.Services;

namespace NWSDB.Client
{
    public partial class UsageHistoryForm : Form
    {
        private readonly ApiService _apiService;
        private readonly CustomerDto _customer;
        private readonly IReadOnlyList<WaterConnectionDto> _connections;

        public UsageHistoryForm(ApiService apiService, CustomerDto customer, IReadOnlyList<WaterConnectionDto> connections)
        {
            InitializeComponent();
            UiHelper.ApplyGridStyle(dgvUsageHistory);
            _apiService = apiService;
            _customer = customer;
            _connections = connections;
            lblCustomer.Text = UiHelper.DescribeCustomer(customer);
        }

        private async void UsageHistoryForm_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                var readings = await _apiService.GetUsageHistoryAsync(_customer.CustomerId);

                dgvUsageHistory.DataSource = readings
                    .Select(r => new UsageRow(
                        UiHelper.FormatDate(r.ReadingDate),
                        UiHelper.DescribeConnection(_connections, r.ConnectionId),
                        r.PreviousReading.ToString("N2"),
                        r.CurrentReading.ToString("N2"),
                        r.UnitsConsumed.ToString("N2")))
                    .ToList();

                lblSummary.Text = readings.Count == 0
                    ? "No meter readings have been recorded for this account."
                    : $"{readings.Count} meter reading(s)   |   Total consumption: {UiHelper.FormatUnits(readings.Sum(r => r.UnitsConsumed))}";
            }
            catch (ApiException ex)
            {
                lblSummary.Text = "Usage history could not be loaded.";
                UiHelper.ShowApiError(this, ex, "load your usage history");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        // Display-ready row for the grid (property names match DataPropertyName in the designer).
        internal sealed record UsageRow(
            string ReadingDate, string Connection, string PreviousReading, string CurrentReading, string UnitsConsumed);
    }
}
