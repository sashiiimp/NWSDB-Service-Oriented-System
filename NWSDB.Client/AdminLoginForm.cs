using System.Net;
using NWSDB.Client.Helpers;
using NWSDB.Client.Models;
using NWSDB.Client.Services;

namespace NWSDB.Client
{
    // Staff sign-in via POST /api/admin/login. On success the returned JWT is
    // attached to the shared ApiService for the admin endpoints.
    public partial class AdminLoginForm : Form
    {
        private readonly ApiService _apiService;

        public AdminLoginForm(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        public AdminLoginResponseDto? Session { get; private set; }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            if (username.Length == 0 || password.Length == 0)
            {
                UiHelper.ShowValidation(this, "Please enter both your username and password.");
                (username.Length == 0 ? txtUsername : txtPassword).Focus();
                return;
            }

            SetBusy(true);
            try
            {
                Session = await _apiService.AdminLoginAsync(new AdminLoginRequestDto { Username = username, Password = password });
                Session.ExpiresAtUtc = AsUtc(Session.ExpiresAtUtc);
                _apiService.SetAdminToken(Session.Token);
                DialogResult = DialogResult.OK;
            }
            catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                MessageBox.Show(this, "Invalid username or password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Clear();
                txtPassword.Focus();
            }
            catch (ApiException ex)
            {
                UiHelper.ShowApiError(this, ex, "sign in");
            }
            finally
            {
                SetBusy(false);
            }
        }

        // The server sends expiresAtUtc with a "Z" suffix, which System.Text.Json reads
        // as DateTimeKind.Utc. Normalise anyway so every expiry check compares
        // UTC with DateTime.UtcNow, never with local time.
        private static DateTime AsUtc(DateTime value) => value.Kind switch
        {
            DateTimeKind.Utc => value,
            DateTimeKind.Local => value.ToUniversalTime(),
            _ => DateTime.SpecifyKind(value, DateTimeKind.Utc)
        };

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SetBusy(bool busy)
        {
            btnLogin.Enabled = !busy;
            btnLogin.Text = busy ? "Signing in..." : "Login";
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
        }
    }
}
