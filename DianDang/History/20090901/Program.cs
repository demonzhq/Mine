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
            login.ShowDialog();
            if (login.DialogResult.Equals(DialogResult.OK))
            {
                login.Close();
                Application.Run(new MainForm());
            }
        }
    }
}