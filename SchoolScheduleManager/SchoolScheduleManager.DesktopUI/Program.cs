using SchoolScheduleManager.DesktopUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolScheduleManager.DesktopUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm frmLogin = new LoginForm();
            if (frmLogin.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Application.Run(new MainForm());
     
        }
    }
}
