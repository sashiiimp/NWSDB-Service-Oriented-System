using System.Net;
using NWSDB.Client.Helpers;
using NWSDB.Client.Models;
using NWSDB.Client.Services;

namespace NWSDB.Client
{
    // Main screen for the NWSDB Admin actor: lists every water connection with
    // its latest reading, and lets the admin record readings and generate bills.
    public partial class AdminDashboardForm : Form
    {
        private readonly ApiService _apiService;
        private readonly AdminLoginResponseDto _session;

        public AdminDashboardForm(ApiService apiService, AdminLoginResponseDto session)
        {
            InitializeComponent();
            UiHelper.ApplyGridStyle(dgvConnections);
            _apiService = apiService;
            _session = session;
            lblSubtitle.Text = $"Signed in as {session.FullName} ({session.Username})   |   " +
                               $"Session expires {UiHelper.FormatDateTime(session.ExpiresAtUtc.ToLocalTime())}";
            UpdateButtons();
        }

        // True when the admin pressed Logout or the session expired (return to the login screen).
        public bool LoggedOut { get; private set; }

        private AdminConnectionDto? SelectedConnection =>
            (dgvConnections.CurrentRow?.DataBoundItem as ConnectionRow)?.Source;

        private async void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            await LoadConnectionsAsync(selectConnectionId: null);
        }

        private async Task LoadConnectionsAsync(int? selectConnectionId)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                var connections = await _apiService.GetAdminConnectionsAsync();

                var rows = connections.Select(c => new ConnectionRow(
                    c,
                    c.ConnectionNumber,
                    c.CustomerName,
                    c.AccountNumber,
                    c.ConnectionAddress,
                    c.Status,
                    c.LatestReadingValue?.ToString("N2") ?? "None",
                    c.LatestReadingDate is DateTime date ? UiHelper.FormatDate(date) : "-")).ToList();

                dgvConnections.DataSource = rows;
                lblSummary.Text = $"{connections.Count} water connection(s)   |   " +
                                  "Select a connection, then record its meter reading or generate a bill.";

                var index = rows.FindIndex(r => r.Source.ConnectionId == selectConnectionId);
                if (index >= 0)
                {
                    dgvConnections.CurrentCell = dgvConnections.Rows[index].Cells[0];
                }
            }
            catch (ApiException ex)
            {
                if (!HandleSessionExpired(ex))
                {
                    lblSummary.Text = "Connections could not be loaded.";
                    UiHelper.ShowApiError(this, ex, "load water connections");
                }
            }
            finally
            {
                Cursor = Cursors.Default;
                UpdateButtons();
            }
        }

        private void dgvConnections_SelectionChanged(object sender, EventArgs e) => UpdateButtons();

        private void UpdateButtons()
        {
            var connection = SelectedConnection;
            btnRecordReading.Enabled = connection is not null;
            btnGenerateBill.Enabled = connection?.LatestReadingId is not null;
        }

        private async void btnRecordReading_Click(object sender, EventArgs e)
        {
            if (SelectedConnection is not AdminConnectionDto connection)
            {
                return;
            }

            MeterReadingDto? reading;
            using (var form = new RecordMeterReadingForm(_apiService, connection))
            {
                var result = form.ShowDialog(this);
                if (result == DialogResult.Abort)
                {
                    EndSession();
                    return;
                }
                reading = result == DialogResult.OK ? form.RecordedReading : null;
            }

            if (reading is null)
            {
                return;
            }

            var generateNow = MessageBox.Show(this,
                $"Meter reading saved for {connection.ConnectionNumber}.\n\n" +
                $"Previous reading: {reading.PreviousReading:N2}\n" +
                $"Current reading: {reading.CurrentReading:N2}\n" +
                $"Units consumed: {UiHelper.FormatUnits(reading.UnitsConsumed)}\n\n" +
                "Generate a bill for this reading now?",
                "Reading Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (generateNow == DialogResult.Yes)
            {
                await GenerateBillAsync(reading.ReadingId, connection.ConnectionNumber);
            }

            await LoadConnectionsAsync(connection.ConnectionId);
        }

        private async void btnGenerateBill_Click(object sender, EventArgs e)
        {
            if (SelectedConnection is not { LatestReadingId: int readingId } connection)
            {
                return;
            }

            var confirm = MessageBox.Show(this,
                $"Generate a bill for {connection.ConnectionNumber} ({connection.CustomerName}) using the reading of " +
                $"{connection.LatestReadingValue:N2} taken on {UiHelper.FormatDate(connection.LatestReadingDate!.Value)}?",
                "Generate Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                await GenerateBillAsync(readingId, connection.ConnectionNumber);
            }
        }

        private async Task GenerateBillAsync(int readingId, string connectionNumber)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                var bill = await _apiService.GenerateBillAsync(new GenerateBillRequestDto { ReadingId = readingId });

                MessageBox.Show(this,
                    $"Bill {UiHelper.FormatBillNumber(bill.BillId)} generated for {connectionNumber}.\n\n" +
                    $"Billing period: {UiHelper.FormatPeriod(bill.BillingPeriodStart, bill.BillingPeriodEnd)}\n" +
                    $"Units consumed: {UiHelper.FormatUnits(bill.UnitsConsumed)}\n" +
                    $"Amount: {UiHelper.FormatCurrency(bill.Amount)}\n" +
                    $"Issued: {UiHelper.FormatDate(bill.IssuedDate)}\n" +
                    $"Due: {UiHelper.FormatDate(bill.DueDate)}\n" +
                    $"Status: {UiHelper.SplitWords(bill.Status)}",
                    "Bill Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ApiException ex) when (ex.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.NotFound or HttpStatusCode.Conflict)
            {
                // e.g. the period has already been billed, or the reading has no consumption.
                MessageBox.Show(this, ex.Message, "Bill Not Generated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ApiException ex)
            {
                if (!HandleSessionExpired(ex))
                {
                    UiHelper.ShowApiError(this, ex, "generate the bill");
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            using var form = new AdminCustomersForm(_apiService);
            if (form.ShowDialog(this) == DialogResult.Abort)
            {
                EndSession();
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e) =>
            await LoadConnectionsAsync(SelectedConnection?.ConnectionId);

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show(this, "Are you sure you want to log out of the Admin Console?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                LoggedOut = true;
                Close();
            }
        }

        // A 401 from an admin endpoint means the JWT has expired or is invalid.
        private bool HandleSessionExpired(ApiException ex)
        {
            if (ex.StatusCode != HttpStatusCode.Unauthorized)
            {
                return false;
            }

            EndSession();
            return true;
        }

        private void EndSession()
        {
            MessageBox.Show(this, "Your admin session has expired. Please log in again.", "Session Expired",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoggedOut = true;
            Close();
        }

        private void AdminDashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Never leave the admin token on the shared HttpClient after leaving the console.
            _apiService.ClearAdminToken();
        }

        internal sealed record ConnectionRow(
            AdminConnectionDto Source, string ConnectionNumber, string CustomerName, string AccountNumber,
            string ConnectionAddress, string Status, string LatestReading, string LatestReadingDate);
    }
}
