using System.Globalization;
using NWSDB.Client.Models;
using NWSDB.Client.Services;

namespace NWSDB.Client.Helpers;

// Shared formatting, styling and error-display helpers so every form looks
// and behaves consistently.
public static class UiHelper
{
    public static readonly Color PrimaryColor = Color.FromArgb(11, 79, 138);
    public static readonly Color AccentColor = Color.FromArgb(0, 122, 204);
    public static readonly Color PageBackColor = Color.FromArgb(244, 247, 251);

    private static readonly CultureInfo DisplayCulture = CultureInfo.GetCultureInfo("en-GB");

    public static string FormatCurrency(decimal amount) =>
        "Rs. " + amount.ToString("N2", DisplayCulture);

    public static string FormatUnits(decimal units) =>
        units.ToString("N2", DisplayCulture) + " units";

    public static string FormatDate(DateTime date) =>
        date.ToString("dd MMM yyyy", DisplayCulture);

    public static string FormatDateTime(DateTime date) =>
        date.ToString("dd MMM yyyy HH:mm", DisplayCulture);

    public static string FormatPeriod(DateTime start, DateTime end) =>
        $"{FormatDate(start)} - {FormatDate(end)}";

    // Adds spaces to enum-style values returned by the API, e.g. "PartiallyPaid" -> "Partially Paid".
    public static string SplitWords(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        var builder = new System.Text.StringBuilder(value.Length + 4);
        for (var i = 0; i < value.Length; i++)
        {
            if (i > 0 && char.IsUpper(value[i]) && !char.IsUpper(value[i - 1]))
            {
                builder.Append(' ');
            }
            builder.Append(value[i]);
        }
        return builder.ToString();
    }

    // Colour used for a bill status so overdue/unpaid bills stand out.
    public static Color GetStatusColor(string status) => status switch
    {
        "Paid" => Color.FromArgb(25, 135, 84),
        "PartiallyPaid" => Color.FromArgb(204, 122, 0),
        "Overdue" => Color.FromArgb(200, 35, 51),
        _ => Color.FromArgb(33, 37, 41)
    };

    // Read-only, full-row-select grid with a consistent header style.
    public static void ApplyGridStyle(DataGridView grid)
    {
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.AllowUserToResizeRows = false;
        grid.ReadOnly = true;
        grid.MultiSelect = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.RowHeadersVisible = false;
        grid.AutoGenerateColumns = false;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.BackgroundColor = Color.White;
        grid.BorderStyle = BorderStyle.FixedSingle;
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        grid.ColumnHeadersHeight = 34;
        grid.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = PrimaryColor;
        grid.ColumnHeadersDefaultCellStyle.Font = new Font(grid.Font, FontStyle.Bold);
        grid.RowTemplate.Height = 28;
        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 250);
        grid.DefaultCellStyle.SelectionBackColor = AccentColor;
        grid.DefaultCellStyle.SelectionForeColor = Color.White;
    }

    public static string DescribeCustomer(CustomerDto customer) =>
        $"{customer.FullName}   |   Account No: {customer.AccountNumber}";

    // Bills and readings only carry a ConnectionId, so the connection number is
    // looked up from the connections the dashboard already loaded.
    public static string DescribeConnection(IReadOnlyList<WaterConnectionDto> connections, int connectionId) =>
        connections.FirstOrDefault(c => c.ConnectionId == connectionId)?.ConnectionNumber ?? $"Connection #{connectionId}";

    public static string FormatBillNumber(int billId) => $"#{billId}";

    public static void ShowApiError(IWin32Window owner, ApiException ex, string action)
    {
        var title = ex.IsConnectionError ? "Service Unavailable" : "NWSDB Service Error";
        var icon = ex.IsConnectionError ? MessageBoxIcon.Error : MessageBoxIcon.Warning;
        MessageBox.Show(owner, $"Could not {action}.\n\n{ex.Message}", title, MessageBoxButtons.OK, icon);
    }

    public static void ShowValidation(IWin32Window owner, string message) =>
        MessageBox.Show(owner, message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}
