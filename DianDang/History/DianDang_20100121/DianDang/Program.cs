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

            String sysFolder = System.Environment.SystemDirectory;//��ȡϵͳ��װĿ¼�磺c:\windows\system32
            Reg rg=new Reg();//�������м�����������ȡCPU���кţ����ַ�������MD5����ȣ�
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SearchPawnInfoForm());
            if (!File.Exists(sysFolder + "\\ddreg.ini"))
            {
                //���ע���ļ������ڡ�ע��ʧ��
                //����ע���ļ�
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
            {//���ע���ļ����ڣ���ȡ�ļ����ݸ�����Ƚ�
                byte[] arry = new byte[32];
                string str = "";
                FileInfo fi = new FileInfo(sysFolder + "\\ddreg.ini");
                FileStream fs = fi.OpenRead();
                int i = fs.Read(arry, 0, 32);
                fs.Close();
                str = System.Text.Encoding.ASCII.GetString(arry);
                if (str == rg.getMd5(rg.GetCpuID()).Trim())//���ע���ļ�����ַ����;���MD5�������ע������ͬ����ע��ɹ�
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