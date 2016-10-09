using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RandomPick
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
            DateTime Ender = new DateTime(2008, 12, 1);
            DateTime Starter = new DateTime(2008, 11, 20);
            /*if (DateTime.Now > Ender || DateTime.Now < Starter)
                Application.Exit();
            else*/ Application.Run(new RandomPick_Conf());
        }
    }
}
