using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PimpMyRide.WindowsFormsApp
{
    static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var pimpMyRideForm = new PimpMyRideForm();
            var game = new WindowsFormsGame(pimpMyRideForm);
            game.Run();
            Application.Run(pimpMyRideForm);
        }
    }
}
