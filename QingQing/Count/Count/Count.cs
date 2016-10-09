using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Count
{
    public partial class Count : Form
    {
        public Count()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            List<string> result = new List<string>();
            string[] temp = textBox1.Text.Split('\n');
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != "\r" && temp[i] != "")
                {
                    int index = -1;
                    index = result.IndexOf(temp[i]);
                    if (index == -1)
                    {
                        result.Add(temp[i]);
                    }
                }
            }
            this.label1.Text = result.Count.ToString();
            foreach (string T in result)
            {
                textBox2.Text += T.ToString();
                textBox2.Text += "\n";
            }
        }
    }
}
