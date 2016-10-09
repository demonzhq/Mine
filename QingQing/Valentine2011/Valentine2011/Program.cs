using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Valentine2011
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (DateTime.Now >= new DateTime(2011, 2, 14) && DateTime.Now < new DateTime(2011, 2, 15))
                Application.Run(new StartFrm());
        }
    }
}
