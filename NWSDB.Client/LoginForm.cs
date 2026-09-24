using NWSDB.Client.Helpers;
using NWSDB.Client.Models;
using NWSDB.Client.Services;

namespace NWSDB.Client
{
    // Start screen. The server has no customer password authentication, so the
    // customer is identified by their NWSDB account number only.
    public partial class LoginForm : Form
    {
        private readonly ApiService _apiService;

        public LoginForm(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
            lblServer.Text = $"Service: {ApiSettings.BaseUrl}";
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var accountNumber = txtAccountNumber.Text.Trim().ToUpperInvariant();

            if (string.IsNullOrEmpty(accountNumber))
            {
                UiHelper.ShowValidation(this, "Please enter your NWSDB account number.");
                txtAccountNumber.Focus();
                return;
            }

            CustomerDto customer;
            SetBusy(true);
            try
            {
                customer = await _apiService.GetCustomerByAccountNumberAsync(accountNumber);
            }
            catch (ApiException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                MessageBox.Show(this,
                    $"No customer account was found for '{accountNumber}'.\nPlease check the account number and try again.",
                    "Account Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccountNumber.SelectAll();
                txtAccountNumber.Focus();
                return;
            }
            catch (ApiException ex)
            {
                UiHelper.ShowApiError(this, ex, "log in");
                return;
            }
            finally
            {
                SetBusy(false);
            }

            OpenDashboard(customer);
        }

        private void OpenDashboard(CustomerDto customer)
        {
            Hide();
            using (var dashboard = new DashboardForm(_apiService, customer))
            {
                dashboard.ShowDialog();

                if (!dashboard.LoggedOut)
                {
                    // Dashboard was closed with the window's X button - exit the application.
                    Close();
                    return;
                }
            }

            // Logout: clear the previous customer's details and return to the login screen.
            txtAccountNumber.Clear();
            Show();
            txtAccountNumber.Focus();
        }

        // Entry point for the NWSDB Admin actor; the customer flow above is unchanged.
        private void lnkAdminLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminLoginResponseDto? session;
            using (var adminLogin = new AdminLoginForm(_apiService))
            {
                if (adminLogin.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                session = adminLogin.Session;
            }

            if (session is null)
            {
                return;
            }

            Hide();
            using (var adminDashboard = new AdminDashboardForm(_apiService, session))
            {
                adminDashboard.ShowDialog();

                if (!adminDashboard.LoggedOut)
                {
                    Close();
                    return;
                }
            }

            txtAccountNumber.Clear();
            Show();
            txtAccountNumber.Focus();
        }

        private void SetBusy(bool busy)
        {
            btnLogin.Enabled = !busy;
            txtAccountNumber.Enabled = !busy;
            btnLogin.Text = busy ? "Signing in..." : "Login";
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
        }
    }
}
