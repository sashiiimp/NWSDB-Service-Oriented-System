using NWSDB.Client.Helpers;
using NWSDB.Client.Models;
using NWSDB.Client.Services;

namespace NWSDB.Client
{
    // Main menu for a logged-in customer: profile, connections and navigation
    // to the usage, billing and payment screens.
    public partial class DashboardForm : Form
    {
        private readonly ApiService _apiService;
        private readonly CustomerDto _customer;
        private List<WaterConnectionDto> _connections = new();

        public DashboardForm(ApiService apiService, CustomerDto customer)
        {
            InitializeComponent();
            UiHelper.ApplyGridStyle(dgvConnections);
            _apiService = apiService;
            _customer = customer;
            ShowCustomer();
        }

        // True when the user pressed Logout (as opposed to closing the window).
        public bool LoggedOut { get; private set; }

        private void ShowCustomer()
        {
            lblWelcome.Text = $"Welcome, {_customer.FullName}";
            lblAccountHeader.Text = $"Account No: {_customer.AccountNumber}";
            lblName.Text = _customer.FullName;
            lblAccountNumber.Text = _customer.AccountNumber;
            lblEmail.Text = _customer.Email;
            lblPhone.Text = _customer.Phone;
            lblAddress.Text = _customer.Address;
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                _connections = await _apiService.GetConnectionsAsync(_customer.CustomerId);
                dgvConnections.DataSource = _connections;
                grpConnections.Text = $"Water Connections ({_connections.Count})";
            }
            catch (ApiException ex)
            {
                UiHelper.ShowApiError(this, ex, "load your water connections");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnCurrentUsage_Click(object sender, EventArgs e) =>
            OpenChild(new CurrentUsageForm(_apiService, _customer, _connections));

        private void btnUsageHistory_Click(object sender, EventArgs e) =>
            OpenChild(new UsageHistoryForm(_apiService, _customer, _connections));

        private void btnCurrentBill_Click(object sender, EventArgs e) =>
            OpenChild(new CurrentBillForm(_apiService, _customer, _connections));

        private void btnBillHistory_Click(object sender, EventArgs e) =>
            OpenChild(new BillHistoryForm(_apiService, _customer, _connections));

        private void btnMakePayment_Click(object sender, EventArgs e) =>
            OpenChild(new MakePaymentForm(_apiService, _customer, _connections));

        private void btnPaymentHistory_Click(object sender, EventArgs e) =>
            OpenChild(new PaymentHistoryForm(_apiService, _customer));

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show(this, "Are you sure you want to log out?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                LoggedOut = true;
                Close();
            }
        }

        private void OpenChild(Form form)
        {
            using (form)
            {
                form.ShowDialog(this);
            }
        }
    }
}
