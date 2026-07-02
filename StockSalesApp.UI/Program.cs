using System.Windows.Forms;

namespace StockSalesApp.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var loginForm = new frmLogin();
            loginForm.Show();

            // Application.Run() formsuz çalışır
            // Uygulama yalnızca Application.Exit() çağrılınca kapanır
            Application.Run();
        }
    }
}