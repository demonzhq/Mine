using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {

        Authorization.Autho mAutho = new Authorization.Autho("CJLRCCFToolsTest1.0", "Autho.lic", "TestTest");
        public Form1()
        {
            InitializeComponent();

            this.Shown += Form1_Shown;
        }

        void Form1_Shown(object sender, EventArgs e)
        {
            System.Threading.Thread AuthoThread = new System.Threading.Thread(AuthoProcess);
            AuthoThread.Start();

        }

        private void AuthoProcess()
        {
            bool Result = mAutho.AuthoProcess();
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
                if (Message != "")
                {
                    MessageBox.Show(Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                Message = Message + "License Error";
                Application.Exit();
                MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
