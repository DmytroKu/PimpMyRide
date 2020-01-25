using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PimpMyRide.WindowsFormsApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var pimpMyRideForm = new PimpMyRideForm();
            var game = new WindowsFormsGame(pimpMyRideForm);
            ApplicationContext context = new ApplicationContext(pimpMyRideForm);
            Task.Run(() => game.Run());
            Application.Run(context);
        }
    }
}
