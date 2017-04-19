using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _160X_Ray
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
            try
            {
                Process[] PList = Process.GetProcessesByName("160X-Ray");
                if (PList.Length > 1)
                {
                    throw new Exception("程序已经启动");
                }
                Application.Run(new Form1());
            }
            catch(Exception Error)
            {
                //MessageBox.Show(Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
