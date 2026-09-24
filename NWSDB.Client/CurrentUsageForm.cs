using NWSDB.Client.Helpers;
using NWSDB.Client.Models;
using NWSDB.Client.Services;

namespace NWSDB.Client
{
    // Shows the latest meter reading. The API returns one latest reading per
    // connection, so a customer with several connections can switch between them.
    public partial class CurrentUsageForm : Form
    {
        private readonly ApiService _apiService;
        private readonly CustomerDto _customer;
        private readonly IReadOnlyList<WaterConnectionDto> _connections;
        private List<MeterReadingDto> _readings = new();

        public CurrentUsageForm(ApiService apiService, CustomerDto customer, IReadOnlyList<WaterConnectionDto> connections)
        {
            InitializeComponent();
            _apiService = apiService;
            _customer = customer;
            _connections = connections;
            lblCustomer.Text = UiHelper.DescribeCustomer(customer);
        }

        private async void CurrentUsageForm_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                _readings = await _apiService.GetCurrentUsageAsync(_customer.CustomerId);
            }
            catch (ApiException ex)
            {
                UiHelper.ShowApiError(this, ex, "load your current usage");
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if (_readings.Count == 0)
            {
                cmbConnection.Enabled = false;
                grpReading.Text = "No meter readings are available for this account yet.";
                return;
            }

            foreach (var reading in _readings)
            {
                cmbConnection.Items.Add(UiHelper.DescribeConnection(_connections, reading.ConnectionId));
            }
            cmbConnection.SelectedIndex = 0;
        }

        private void cmbConnection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConnection.SelectedIndex < 0)
            {
                return;
            }

            var reading = _readings[cmbConnection.SelectedIndex];
            var connection = _connections.FirstOrDefault(c => c.ConnectionId == reading.ConnectionId);

            lblConnectionAddress.Text = connection?.ConnectionAddress ?? "-";
            lblReadingDate.Text = UiHelper.FormatDate(reading.ReadingDate);
            lblPreviousReading.Text = reading.PreviousReading.ToString("N2");
            lblCurrentReading.Text = reading.CurrentReading.ToString("N2");
            lblUnitsConsumed.Text = UiHelper.FormatUnits(reading.UnitsConsumed);
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
