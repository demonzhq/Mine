using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TestForm
{
    public partial class Form1 : Form
    {
        string StrFooter;
        string StrData;
        DataReceiver dr = new DataReceiver();
        public Form1()
        {
            InitializeComponent();
            dr.ClientConnected += this.ClientConnected;
            dr.ClientDisconnected += this.ClientDisconnected;
            dr.DataReceived += this.DataReceived;
            dr.MessageReceived += this.TCPMessageReceived;
            
           

        }



        #region EventHandler


        private void ClientConnected()
        {
            StrFooter = "Connected";
            this.SSFooter.BeginInvoke(new EventHandler(UpdateFooter));
        }
        private void ClientDisconnected(string ErrorMessage)
        {

            //StrFooter = ErrorMessage;
            //this.SSFooter.BeginInvoke(new EventHandler(UpdateFooter));
        }
        private void DataReceived(string mData)
        {
            StrData = mData;
            this.tbxData.BeginInvoke(new EventHandler(UpdateData));
        }
        private void TCPMessageReceived(string msg)
        {
            this.StrFooter = msg;
            this.tbxData.BeginInvoke(new EventHandler(UpdateFooter));
        }
        #endregion





        protected void UpdateFooter(Object o, EventArgs e)
        {
            FooterLabel.Text = StrFooter;
        }

        protected void UpdateData(Object o, EventArgs e)
        {
            this.tbxData.AppendText("\r\n");
            this.tbxData.AppendText(StrData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dr.Run();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dr.Stop();
        }
    }
}
