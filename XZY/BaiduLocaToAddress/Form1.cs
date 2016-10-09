using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Authorization;


namespace BaiduLocaToAddress
{
    public partial class Form1 : XForm.XForm
    {

        //string key = "RdfOyuyMP2ajeU1qSmF8vcQr";
        //string key = "29ce729a15887191a6213c117c0cecf0";
        string key = "";
        


        public Form1()
        {
            this.setSaveMode();
            System.Threading.Thread AuthoThread = new System.Threading.Thread(AuthoProcess);
            AuthoThread.Start();
            InitializeComponent();


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

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string[] RequestList = textBox1.Text.Trim().Split('\n');
            if (!(RequestList == null))
            {
                foreach (string t in RequestList)
                {
                    textBox2.AppendText(Local2Address(t) + "\r\n");
                }
                //textBox2.Text =Result;
                MessageBox.Show("finished");
                textBox2.SelectAll();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            string[] RequestList = textBox2.Text.Trim().Split('\n');
            if (!(RequestList == null))
            {
                foreach (string t in RequestList)
                {
                    textBox1.AppendText(Address2Local(t) + "\r\n");
                }
                //textBox1.Text = Result;
                MessageBox.Show("finished");
                textBox1.SelectAll();
            }
        }

        Autho mAutho = new Autho("NilsenLocalToAddress", "Autho.lic", "LOCLADDR");


        private string Local2Address(string mLocal)
        {
            key = tbxKey.Text.Trim();
            string url = "http://api.map.baidu.com/geocoder/v2/?ak=" + key + "&callback=renderOption&output=xml&location=";
            XmlDocument p = new XmlDocument();
            string Request = url + mLocal.Trim();
            try
            {
                p.Load(Request);
                XmlNode ele = p.GetElementsByTagName("formatted_address")[0];
                return ele.InnerText;
            }
            catch
            {
                return "---Failure---";
            }
        }

        private string Address2Local(string mAddress)
        {
            key = tbxKey.Text.Trim();
            string url = "http://api.map.baidu.com/geocoder/v2/?ak=" + key + "&callback=renderOption&output=xml&address=";
            XmlDocument p = new XmlDocument();
            string Request = url + mAddress.Trim();

            try
            {
                p.Load(Request);
                XmlNode lat = p.GetElementsByTagName("lat")[0];
                XmlNode lng = p.GetElementsByTagName("lng")[0];
                return (lat.InnerText + "," + lng.InnerText);
            }
            catch
            {
                return "---------Failure-------------";
            }
        }

        private void btnBrowseExcel_Click(object sender, EventArgs e)
        {
            if (ofdExcelFile.ShowDialog() == DialogResult.OK)
            {
                this.tbxExcelFile.Text = ofdExcelFile.FileName;
            }
        }

        private void btnExcelLocaltoAddress_Click(object sender, EventArgs e)
        {
            int LocalCol = (int)this.nudLocalCol.Value;
            int AddressCol = (int)this.nudAddressCol.Value;
            int StartRow = (int)this.nudDataStartRow.Value;
            Microsoft.Office.Interop.Excel.Application xlApp = null;
            Microsoft.Office.Interop.Excel.Workbook xlBook = null;
            Microsoft.Office.Interop.Excel.Worksheet xlSheet = null;
            object missing = System.Reflection.Missing.Value;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlBook = xlApp.Workbooks.Add(tbxExcelFile.Text);
            xlSheet = xlBook.Sheets[1];
            xlApp.Visible = true;

            string mLocal = xlSheet.Cells[LocalCol][StartRow].Value;
            for (int i = 0;mLocal!= null; i++)
            {
                xlSheet.Cells[AddressCol][StartRow + i].Value = Local2Address(mLocal);
                mLocal = xlSheet.Cells[LocalCol][StartRow + i + 1].Value;
            }
            MessageBox.Show("Convert Finished");
        }

        private void btnAddresstoLocal_Click(object sender, EventArgs e)
        {
            int LocalCol = (int)this.nudLocalCol.Value;
            int AddressCol = (int)this.nudAddressCol.Value;
            int StartRow = (int)this.nudDataStartRow.Value;
            Microsoft.Office.Interop.Excel.Application xlApp = null;
            Microsoft.Office.Interop.Excel.Workbook xlBook = null;
            Microsoft.Office.Interop.Excel.Worksheet xlSheet = null;
            object missing = System.Reflection.Missing.Value;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlBook = xlApp.Workbooks.Add(tbxExcelFile.Text);
            xlSheet = xlBook.Sheets[1];
            xlApp.Visible = true;

            string mAddress = xlSheet.Cells[AddressCol][StartRow].Value;
            for (int i = 0; mAddress != null; i++)
            {
                xlSheet.Cells[LocalCol][StartRow + i].Value = Address2Local(mAddress);
                mAddress = xlSheet.Cells[AddressCol][StartRow + i + 1].Value;
            }
            MessageBox.Show("Convert Finished");
        }
    }
}
