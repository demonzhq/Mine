using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIN32API;
using System.IO;
using System.Diagnostics;
using Authorization;
using System.Xml;

namespace _160X_Ray
{
    public partial class Form1 : Form
    {

        Autho mAutho = new Autho("ZhuoXing160X-Ray", "Autho.lic", "ZhuoXing");
        bool isAutho = false;
        string ApplicationPath;
        private Process App;
        private bool isTicking = false;
        private int LastTime = 0;
        private int TimeLeft = 0;


        string TipSettingTime = "设置延时时间";
        string TipTimerNotStart = "计时未开始";


        TipForm fmTip = new TipForm();

        public Form1()
        {
            InitializeComponent();


            GetValue();
            this.MainMinute.Value = LastTime / 60;
            this.MainSecond.Value = LastTime % 60;

            AuthoProcess();
            //isAutho = true;

            if (isAutho)
            {
                if (!FindApplicationPath())
                {
                    MessageBox.Show("没有找到启动程序，程序终止", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();
                }
                else
                {


                    Process[] PList = Process.GetProcessesByName("IXS160BP480P097");
                    if (PList.Length != 0)
                    {
                        App = PList[0];
                    }
                    else
                    {
                        App = Process.Start(ApplicationPath);
                    }
                    App.EnableRaisingEvents = true;
                    App.Exited += new EventHandler(App_Exited);
                }

            }
            else
            {
                Application.Exit();
                this.Dispose();
            }



        }





        private void App_Exited(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool FindApplicationPath()
        {
            bool Result;
            if (File.Exists("C:\\Program Files (x86)\\IXS160BP480P097\\IXS160BP480P097.exe"))
            {
                ApplicationPath = "C:\\Program Files (x86)\\IXS160BP480P097\\IXS160BP480P097.exe";
                Result = true;
            }
            else if (File.Exists("C:\\Program Files\\IXS160BP480P097\\IXS160BP480P097.exe"))
            {
                ApplicationPath = "C:\\Program Files\\IXS160BP480P097\\IXS160BP480P097.exe";
                Result = true;
            }
            else
            {
                ApplicationPath = "";
                Result = false;
            }
            return Result;
        }




        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (App != null)
            {
                //StopAction();
                try
                {
                    App.Kill();
                }
                catch
                {

                }
                
            }
            this.niMain.Dispose();
            SaveValue();
        }



        //StripMenu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (App!=null)
            {
                //StopAction();
                App.Kill();
            }
            Application.Exit();          
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isTicking)
            {

                TimeSettingForm mSettingForm = new TimeSettingForm(LastTime);
                if (mSettingForm.ShowDialog() == DialogResult.OK)
                {
                    isTicking = true;
                    TimeLeft = mSettingForm.Seconds;
                    LastTime = TimeLeft;
                    SaveValue();
                    settingToolStripMenuItem.Text = "停止计时";
                    mTimer.Start();
                    UpdateTimeDisplay();
                    ShowTip();
                }

            }
            else
            {
                isTicking = false;
                settingToolStripMenuItem.Text = TipSettingTime;
                fmTip.SetDisplay(TipTimerNotStart);
                DisplayStripMenuItem.Text = TipTimerNotStart;
                niMain.Text = TipTimerNotStart;
                mTimer.Stop();

            }
        }

        private void mTimer_Tick(object sender, EventArgs e)
        {
            TimeLeft = TimeLeft - 1;
            UpdateTimeDisplay();
            
            if (TimeLeft == 0)
            {
                mTimer.Stop();
                this.fmTip.Hide();
                this.fmTip.SetDisplay(TipTimerNotStart);
                isTicking = false;
                niMain.Text = TipTimerNotStart;
                settingToolStripMenuItem.Text = TipSettingTime;
                DisplayStripMenuItem.Text = TipTimerNotStart;
                StopAction();
                //MessageBox.Show("Tick");
            }
        }


        private void UpdateTimeDisplay()
        {
            DisplayStripMenuItem.Text = (TimeLeft / 60).ToString("00") + " : " + (TimeLeft % 60).ToString("00");
            niMain.Text = DisplayStripMenuItem.Text;
            fmTip.SetDisplay(DisplayStripMenuItem.Text);
        }

        private void niMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)  //单击鼠标左键也弹出菜单
            {
                Control control = new Control(null, Control.MousePosition.X, Control.MousePosition.Y, 1, 1);
                control.Visible = true;
                control.CreateControl();
                Point pos = new Point(0, 0);//这里的两个数字要根据你的上下文菜单大小适当地调整 
                this.cmsMain.Show(control, pos);
            }
        }



        private void StopAction()
        {

            int X = 490;
            int Y = 550;

            Point MouseOriPos = MousePosition;

            
            IntPtr mainWnd = Win32Api.FindWindow(null, "VJ X-Ray Generator");
            if (mainWnd == IntPtr.Zero)
            {
                MessageBox.Show("Process Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Win32Api.ShowWindow(mainWnd, 1);
                Win32Api.SetWindowPos(mainWnd, -1, 0, 0, 0, 0, (int)(Win32Api.SetWindowsPosFlags.SWP_NOREPOSITION | Win32Api.SetWindowsPosFlags.SWP_NOSIZE | Win32Api.SetWindowsPosFlags.SWP_NOMOVE));
                

                
                Win32Api.RECT WindowPos = new Win32Api.RECT();
                Win32Api.GetWindowRect(mainWnd, ref WindowPos);

                Win32Api.SetCursorPos(WindowPos.Left + X, WindowPos.Top + Y);
                Win32Api.mouse_event(Win32Api.MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
                Win32Api.mouse_event(Win32Api.MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);

                Win32Api.SetCursorPos(MouseOriPos.X, MouseOriPos.Y);
                Win32Api.SetWindowPos(mainWnd, -2, 0, 0, 0, 0, (int)(Win32Api.SetWindowsPosFlags.SWP_NOREPOSITION | Win32Api.SetWindowsPosFlags.SWP_NOSIZE | Win32Api.SetWindowsPosFlags.SWP_NOMOVE));
            }

        }


        private void GetValue()
        {
            XmlDocument RootDoc = new XmlDocument();
            try
            {
                RootDoc.Load(Application.StartupPath + "\\app.sav");
                XmlNode TimerNode = RootDoc.SelectSingleNode("_160XRay/Timer");
                LastTime =  (Convert.ToInt32(TimerNode.InnerText));

                XmlNode TipXNode = RootDoc.SelectSingleNode("_160XRay/TipX");
                XmlNode TipYNode = RootDoc.SelectSingleNode("_160XRay/TipY");

                this.fmTip.SetPos(Convert.ToInt32(TipXNode.InnerText), Convert.ToInt32(TipYNode.InnerText));

                XmlNode isTipNode = RootDoc.SelectSingleNode("_160XRay/IsTip");
                if (isTipNode.InnerText == "Yes")
                {
                    isDisplaytoolStripMenuItem.Checked = true;
                }
                else
                {
                    isDisplaytoolStripMenuItem.Checked = false;
                }

            }
            catch(Exception Error)
            {
                CreateSave();
            }
        }

        private void SaveValue()
        {
            XmlDocument RootDoc = new XmlDocument();
            try
            {
                RootDoc.Load(Application.StartupPath + "\\app.sav");
                XmlNode TimerNode = RootDoc.SelectSingleNode("_160XRay/Timer");
                TimerNode.InnerText = LastTime.ToString();

                XmlNode TipXNode = RootDoc.SelectSingleNode("_160XRay/TipX");
                XmlNode TipYNode = RootDoc.SelectSingleNode("_160XRay/TipY");

                TipXNode.InnerText = fmTip.GetPos().X.ToString();
                TipYNode.InnerText = fmTip.GetPos().Y.ToString();



                XmlNode isTipNode = RootDoc.SelectSingleNode("_160XRay/IsTip");
                if (isDisplaytoolStripMenuItem.Checked)
                {
                    isTipNode.InnerText = "Yes";
                }
                else
                {
                    isTipNode.InnerText = "No";
                }

                RootDoc.Save(Application.StartupPath + "\\app.sav");


            }
            catch
            {
                CreateSave();
            }
        }

        private void AuthoProcess()
        {
            string strResult = mAutho.isNetworkAuthorized();
            bool Result = false;
            if (strResult.Split('|')[0] == "1")
            {
                Result = true;
            }
            else Result = false;
            string Message = mAutho.GetMessage();
            if (Message == "void")
            {
                Message = "";
            }
            else
            {
                Message = Message + "\r\n";
            }
            if (Result)
            {
                isAutho = true;
                if (Message != "")
                {
                    MessageBox.Show(Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                isAutho = false;
                Message = Message + "License Error";
                //this.Dispose();

                //Application.Exit();
                MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void CreateSave()
        {
            XmlDocument RootDoc = new XmlDocument();
            XmlDeclaration xdDec = RootDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            RootDoc.AppendChild(xdDec);
            XmlElement RootElement = RootDoc.CreateElement("_160XRay");



            XmlElement LastTimerElement = RootDoc.CreateElement("Timer");
            XmlElement TipXElement = RootDoc.CreateElement("TipX");
            XmlElement TipYElement = RootDoc.CreateElement("TipY");
            XmlElement IsTipElement = RootDoc.CreateElement("IsTip");



            RootDoc.AppendChild(RootElement);
            RootElement.AppendChild(LastTimerElement);
            RootElement.AppendChild(TipXElement);
            RootElement.AppendChild(TipYElement);
            RootElement.AppendChild(IsTipElement);



            LastTimerElement.InnerText = LastTime.ToString();
            TipXElement.InnerText = fmTip.GetPos().X.ToString();
            TipXElement.InnerText = fmTip.GetPos().Y.ToString();

            if (isDisplaytoolStripMenuItem.Checked)
            {
                IsTipElement.InnerText = "Yes";
            }
            else
            {
                IsTipElement.InnerText = "No";
            }

            RootDoc.Save(Application.StartupPath + "\\app.sav");
        }

        private void ShowTip()
        {
            if (isDisplaytoolStripMenuItem.Checked == true)
            {
                fmTip.Show();
            }
            if (isDisplaytoolStripMenuItem.Checked == false)
            {
                fmTip.Hide();
            }
            
        }

        private void isDisplaytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDisplaytoolStripMenuItem.Checked)
            {
                isDisplaytoolStripMenuItem.Checked = false;
            }
            else
            {
                isDisplaytoolStripMenuItem.Checked = true;
            }
            ShowTip();
        }

        private void btnMainOK_Click(object sender, EventArgs e)
        {
            try
            {
                TimeLeft = (int)(MainMinute).Value * 60 + (int)(MainSecond.Value);
                if (TimeLeft > 0 && TimeLeft < 6000)
                {
                    if (!isTicking)
                    {
                        StopAction();   
                    }
                    LastTime = TimeLeft;
                    SaveValue();
                    isTicking = true;
                    settingToolStripMenuItem.Text = "停止计时";
                    mTimer.Start();
                    UpdateTimeDisplay();
                    ShowTip();

                }
                else
                {
                    MessageBox.Show("请输入正确的时间", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.DialogResult = DialogResult.None;
                }

            }
            catch
            {
                MessageBox.Show("请输入正确的时间", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.DialogResult = DialogResult.None;
            }
        }

        private void btnMainStop_Click(object sender, EventArgs e)
        {
            if(isTicking == true)
            {
                StopAction();
            }
            isTicking = false;
            settingToolStripMenuItem.Text = TipSettingTime;
            fmTip.SetDisplay(TipTimerNotStart);
            DisplayStripMenuItem.Text = TipTimerNotStart;
            niMain.Text = TipTimerNotStart;
            mTimer.Stop();
        }
    }
}
