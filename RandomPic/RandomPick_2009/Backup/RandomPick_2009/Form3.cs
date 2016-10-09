using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RandomPick_2009
{
    public partial class Form3 : Form
    {
        public Form2 Second;
        public Form4 Forth;
        List<string> ShowList = new List<string>();
        List<string> TotalList = new List<string>();
        string Interval = "   ";

        public Form3(Form2 theSecond)
        {
            
            Second = theSecond;
            TotalList = Second.Third.Data.UnUsed;
            InitializeComponent();
            label5.Visible = false;
            Forth = new Form4(this);
            Forth.Hide();
        }

        private void RefreshShowBox()
        {
            ShowList.Clear();
            Second.Third.Data.TempIntList = new List<int>();
            Second.Third.Data.TempIntList = Lorder.RandomList(TotalList.Count, 6);
            this.label7.Text = "";
            for (int i = 0; i < 6; i++)
            {
                if (i == 0) label7.Text = label7.Text + TotalList[Second.Third.Data.TempIntList[i]] + Interval;
                else if ((i + 1) % 3 == 0 && i != 5)
                {
                    label7.Text = label7.Text + TotalList[Second.Third.Data.TempIntList[i]] + "\n\n";
                }
                else if (i == 5)
                {
                    label7.Text = label7.Text + TotalList[Second.Third.Data.TempIntList[i]];
                }
                else label7.Text = label7.Text + TotalList[Second.Third.Data.TempIntList[i]] + Interval;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshShowBox();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (label3.Text == "开始！")
            {
                RefreshShowBox();
                timer1.Start();
                timer2.Start();

            }
            if (label3.Text == "停！")
            {
                timer1.Stop();
                timer2.Start();

                #region 一等奖
                Second.Third.Data.TempStringList = new List<string>();
                Second.Third.Data.TempIntList = new List<int>();
                Second.Third.Data.FirstAward.Clear();

                for (int i = 0; i < Second.Third.Data.Special1.Count; i++)
                {
                    Second.Third.Data.FirstAward.Add(Second.Third.Data.Special1[i]);
                }
                for (int i = 0; i < Second.Third.Data.UnUsed.Count; i++)
                {
                    Second.Third.Data.TempStringList.Add(Second.Third.Data.UnUsed[i]);
                }
                for (int i = 0; i < Second.Third.Data.Special1.Count; i++)
                {
                    Second.Third.Data.TempStringList.Remove(Second.Third.Data.Special1[i]);
                }


                Second.Third.Data.TempIntList = Lorder.RandomList(Second.Third.Data.TempStringList.Count, 6 - Second.Third.Data.FirstAward.Count);

                for (int i = 0; i < Second.Third.Data.TempIntList.Count; i++)
                {
                    Second.Third.Data.FirstAward.Add(Second.Third.Data.TempStringList[Second.Third.Data.TempIntList[i]]);
                }

                Second.Third.Data.FirstAward = Lorder.RandomPosition(Second.Third.Data.FirstAward);

                #endregion

                label7.Text = "";
                for (int i = 0; i < 6; i++)
                {
                    if (i == 0) label7.Text = label7.Text + Second.Third.Data.FirstAward[i] + Interval;
                    else if ((i + 1) % 3 == 0 && i != 5)
                    {
                        label7.Text = label7.Text + Second.Third.Data.FirstAward[i] + "\n\n";
                    }
                    else if (i == 5)
                    {
                        label7.Text = label7.Text + Second.Third.Data.FirstAward[i];
                    }
                    else label7.Text = label7.Text + Second.Third.Data.FirstAward[i] + Interval;

                }

                this.label5.Visible = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label3.Text == "开始！")
            {
                label3.Text = "停！";
                timer2.Stop();
                label4.Visible = false;
                label5.Visible = false;
            }
            else if (label3.Text == "停！")
            {
                label3.Text = "开始！";
                timer2.Stop();
                label4.Visible = true;
                //label5.Visible = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Second.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Second.Third.Data.FirstAward.Count; i++)
            {
                Second.Third.Data.UnUsed.Remove(Second.Third.Data.FirstAward[i]);
            }
            this.label3.Visible = false;
            Forth.Show();
        }
    }
}
