using System.Net;
using NWSDB.Client.Helpers;
using NWSDB.Client.Models;
using NWSDB.Client.Services;

namespace NWSDB.Client
{
    // Read-only list of customers (GET /api/admin/customers) with the
    // connections of the selected customer shown underneath.
    public partial class AdminCustomersForm : Form
    {
        private readonly ApiService _apiService;

        public AdminCustomersForm(ApiService apiService)
        {
            InitializeComponent();
            UiHelper.ApplyGridStyle(dgvCustomers);
            UiHelper.ApplyGridStyle(dgvCustomerConnections);
            _apiService = apiService;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Cursor = Cursors.WaitCursor;
            try
            {
                var customers = await _apiService.GetAdminCustomersAsync();
                dgvCustomers.DataSource = customers
                    .Select(c => new CustomerRow(c, c.AccountNumber, c.FullName, c.Email, c.Phone, c.Address, c.Connections.Count))
                    .ToList();
                lblSummary.Text = $"{customers.Count} registered customer(s)   |   " +
                                  $"{customers.Sum(c => c.Connections.Count)} water connection(s)";
            }
            catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                // Let the dashboard handle the expired session.
                DialogResult = DialogResult.Abort;
            }
            catch (ApiException ex)
            {
                lblSummary.Text = "Customers could not be loaded.";
                UiHelper.ShowApiError(this, ex, "load customers");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow?.DataBoundItem is not CustomerRow row)
            {
                return;
            }

            dgvCustomerConnections.DataSource = row.Source.Connections;
            lblConnectionsFor.Text = $"Connections for {row.FullName} ({row.AccountNumber})";
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        internal sealed record CustomerRow(
            AdminCustomerDto Source, string AccountNumber, string FullName, string Email, string Phone,
            string Address, int ConnectionCount);
    }
}
