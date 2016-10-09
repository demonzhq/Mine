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
        public Form1()
        {
            InitializeComponent();

            this.Shown += Form1_Shown;
        }

        void Form1_Shown(object sender, EventArgs e)
        {
            Authorization.Autho mAutho = new Authorization.Autho("Test","Autho.lic","TestTest");
            bool Result = mAutho.AuthoProcess();
            
            if (Result)
            {
                MessageBox.Show("License Good");
            }
            else
            {
                MessageBox.Show("License Error");
                Application.Exit();
            }
        }
    }
}
