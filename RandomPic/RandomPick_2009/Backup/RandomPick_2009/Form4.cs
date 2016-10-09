using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RandomPick_2009
{
    public partial class Form4 : Form
    {
        Form3 First;

        public Form4(Form3 theFrist)
        {
            First = theFrist;
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            First.Show();
        }


        private void CheckAward()
        {
            if (First.Second.Third.Data.FirstAward.Contains(textBox1.Text))
                label2.Text = "一等奖";
            else if (First.Second.Third.Data.SecondAward.Contains(textBox1.Text))
                label2.Text = "二等奖";
            else if (First.Second.Third.Data.ThirdAward.Contains(textBox1.Text))
                label2.Text = "三等奖";
            else if (First.Second.Third.Data.All.Contains(textBox1.Text))
                label2.Text = "阳光普照奖";
            else label2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CheckAward();
        }
    }
}
