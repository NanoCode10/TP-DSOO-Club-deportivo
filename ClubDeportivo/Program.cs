using ClubDeportivo.Forms;
using ClubDeportivo.Forms.cobrar_cuota;
using ClubDeportivo.Forms.menu_home;

namespace ClubDeportivo
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
            Application.Run(new frmMenuPrincipal());
            //Application.Run(new frmLogin());
        }
    }
}