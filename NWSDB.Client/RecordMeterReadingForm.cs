using System.Net;
using NWSDB.Client.Helpers;
using NWSDB.Client.Models;
using NWSDB.Client.Services;

namespace NWSDB.Client
{
    // Records a new reading through POST /api/admin/meter-readings. The units
    // shown here are only a preview; the server validates the reading and
    // calculates the stored UnitsConsumed itself.
    public partial class RecordMeterReadingForm : Form
    {
        private readonly ApiService _apiService;
        private readonly AdminConnectionDto _connection;
        private readonly bool _isFirstReading;

        public RecordMeterReadingForm(ApiService apiService, AdminConnectionDto connection)
        {
            InitializeComponent();
            _apiService = apiService;
            _connection = connection;
            _isFirstReading = connection.LatestReadingValue is null;

            lblSubtitle.Text = $"{connection.ConnectionNumber}   |   {connection.CustomerName} ({connection.AccountNumber})";
            lblConnectionNumber.Text = $"{connection.ConnectionNumber} ({connection.Status})";
            lblCustomer.Text = $"{connection.CustomerName} ({connection.AccountNumber})";
            lblConnectionAddress.Text = connection.ConnectionAddress;
            lblLatestReading.Text = _isFirstReading
                ? "No readings recorded yet"
                : $"{connection.LatestReadingValue:N2} on {UiHelper.FormatDate(connection.LatestReadingDate!.Value)}";

            dtpReadingDate.MaxDate = DateTime.Today;
            dtpReadingDate.Value = DateTime.Today;

            // Previous reading comes from the server for existing connections; it
            // can only be entered for a connection's first ever reading.
            nudPreviousReading.Value = connection.LatestReadingValue ?? 0m;
            nudPreviousReading.Enabled = _isFirstReading;
            nudCurrentReading.Value = nudPreviousReading.Value;
            UpdateUnitsPreview();
        }

        public MeterReadingDto? RecordedReading { get; private set; }

        private void ReadingValue_Changed(object sender, EventArgs e) => UpdateUnitsPreview();

        private void UpdateUnitsPreview()
        {
            var units = nudCurrentReading.Value - nudPreviousReading.Value;
            if (units < 0)
            {
                lblUnitsConsumed.Text = "Current reading is lower than previous";
                lblUnitsConsumed.ForeColor = UiHelper.GetStatusColor("Overdue");
            }
            else
            {
                lblUnitsConsumed.Text = UiHelper.FormatUnits(units);
                lblUnitsConsumed.ForeColor = UiHelper.GetStatusColor("Paid");
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = new CreateMeterReadingRequestDto
            {
                ConnectionId = _connection.ConnectionId,
                ReadingDate = dtpReadingDate.Value.Date,
                CurrentReading = nudCurrentReading.Value,
                PreviousReading = _isFirstReading ? nudPreviousReading.Value : null
            };

            SetBusy(true);
            try
            {
                RecordedReading = await _apiService.RecordMeterReadingAsync(request);
                DialogResult = DialogResult.OK;
            }
            catch (ApiException ex) when (ex.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.NotFound or HttpStatusCode.Conflict)
            {
                // Server-side validation, e.g. "CurrentReading (1215.00) cannot be lower than PreviousReading (1220.00)."
                MessageBox.Show(this, ex.Message, "Reading Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                DialogResult = DialogResult.Abort;
            }
            catch (ApiException ex)
            {
                UiHelper.ShowApiError(this, ex, "save the meter reading");
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void SetBusy(bool busy)
        {
            btnSave.Enabled = !busy;
            btnSave.Text = busy ? "Saving..." : "Save Reading";
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
        }
    }
}
