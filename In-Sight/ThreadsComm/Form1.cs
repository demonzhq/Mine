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

namespace ThreadsComm
{
    public partial class Form1 : Form
    {
        private static string param = "";
        public Form1()
        {
            InitializeComponent();
            MyThread thread1 = new MyThread();
            thread1.ReadParam += this.OnRead;
        }

        private void OnRead(string sParam)
        {
            param = sParam;
            Object[] list = { this, System.EventArgs.Empty };
            this.lblShow.BeginInvoke(new EventHandler(LabelShow), list);
        }
        protected void LabelShow(Object o, EventArgs e)
        {
            this.lblShow.Text = param;
        }
    }
}
