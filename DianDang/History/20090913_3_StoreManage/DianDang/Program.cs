using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DianDang
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


            LoginForm login = new LoginForm();
            if (login.ShowDialog()==DialogResult.OK)
            {
                Application.Run(new MainForm());
            }
        }
    }
}