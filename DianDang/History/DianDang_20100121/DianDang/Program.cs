using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

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

            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            String sysFolder = System.Environment.SystemDirectory;//获取系统安装目录如：c:\windows\system32
            Reg rg=new Reg();//此类里有几个函数（获取CPU序列号，对字符串进行MD5运算等）
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SearchPawnInfoForm());
            if (!File.Exists(sysFolder + "\\ddreg.ini"))
            {
                //如果注册文件不存在。注册失败
                //创建注册文件
                FileStream fs=File.Create(sysFolder + "\\ddreg.ini");
                fs.Close();
                RegForm frmReg = new RegForm();
                if (frmReg.ShowDialog() == DialogResult.OK)
                {
                    LoginForm login = new LoginForm();
                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        Application.Run(new MainForm());
                    }
                }
            }
            else
            {//如果注册文件存在，读取文件内容跟密码比较
                byte[] arry = new byte[32];
                string str = "";
                FileInfo fi = new FileInfo(sysFolder + "\\ddreg.ini");
                FileStream fs = fi.OpenRead();
                int i = fs.Read(arry, 0, 32);
                fs.Close();
                str = System.Text.Encoding.ASCII.GetString(arry);
                if (str == rg.getMd5(rg.GetCpuID()).Trim())//如果注册文件里的字符串和经过MD5运算过的注册码相同，则注册成功
                {
                    LoginForm login = new LoginForm();
                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        Application.Run(new MainForm());
                        
                    }
                }
                else
                {
                    RegForm frmReg = new RegForm();
                    if (frmReg.ShowDialog() == DialogResult.OK)
                    {
                        LoginForm login = new LoginForm();
                        if (login.ShowDialog() == DialogResult.OK)
                        {
                            Application.Run(new MainForm());
                        }
                    }
                }
            }
        }
    }
}