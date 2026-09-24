using NWSDB.Client.Services;

namespace NWSDB.Client
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // A single ApiService (and therefore a single HttpClient) is shared by every form.
            using var apiService = new ApiService();
            Application.Run(new LoginForm(apiService));
        }
    }
}
