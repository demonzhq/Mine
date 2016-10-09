using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RandomPick_2009
{
    public partial class Form2 : Form
    {
        List<string> ShowList = new List<string>();
        List<string> TotalList = new List<string>();
        public Form1 Third;
        public Form3 First;
        string Interval = "   ";
        

        public Form2(Form1 theThird)
        {
            Third = theThird;
            InitializeComponent();
            TotalList = Third.Data.UnUsed;
            label5.Visible = false;
            First = new Form3(this);
            First.Hide();
        }

        private void RefreshShowBox()
        {
            ShowList.Clear();
            Third.Data.TempIntList.Clear();
            Third.Data.TempIntList = Lorder.RandomList(TotalList.Count, 12);
            this.label7.Text = "";
            this.label8.Text = "";
            for (int i = 0; i < 6; i++)
            {
                if (i == 0) label7.Text = label7.Text + TotalList[Third.Data.TempIntList[i]] + Interval;
                else if ((i + 1) % 3 == 0 && i != 5)
                {
                    label7.Text = label7.Text + TotalList[Third.Data.TempIntList[i]] + "\n";
                }
                else if (i == 5)
                {
                    label7.Text = label7.Text + TotalList[Third.Data.TempIntList[i]];
                }
                else label7.Text = label7.Text + TotalList[Third.Data.TempIntList[i]] + Interval;
                
            }
            for (int i = 6; i < 12; i++)
            {
                if (i == 6) label8.Text = label8.Text + TotalList[Third.Data.TempIntList[i]] + Interval;
                else if ((i + 1) % 3 == 0 && i != 11)
                {
                    label8.Text = label8.Text + TotalList[Third.Data.TempIntList[i]] + "\n";
                }
                else if (i == 5)
                {
                    label8.Text = label8.Text + TotalList[Third.Data.TempIntList[i]];
                }
                else label8.Text = label8.Text + TotalList[Third.Data.TempIntList[i]] + Interval;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            for (int i = 0; i < Third.Data.SecondAward.Count; i++)
            {
                Third.Data.UnUsed.Remove(Third.Data.SecondAward[i]);
            }
            this.Hide();
            First.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Third.Show();
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

                #region 二等奖
                Third.Data.TempStringList = new List<string>();
                Third.Data.TempIntList = new List<int>();
                Third.Data.SecondAward.Clear();

                for (int i = 0; i < Third.Data.SecondSpecial.Count; i++)
                {
                    Third.Data.SecondAward.Add(Third.Data.SecondSpecial[i]);
                }

                for (int i = 0; i < Third.Data.UnUsed.Count; i++)
                {
                    Third.Data.TempStringList.Add(Third.Data.UnUsed[i]);
                }

                for (int i = 0; i < Third.Data.Special1.Count; i++)
                {
                    Third.Data.TempStringList.Remove(Third.Data.Special1[i]);
                }

                for (int i = 0; i < Third.Data.SecondAward.Count; i++)
                {
                    //Third.Data.TempStringList.Remove(Third.Data.SecondAward[i]);
                }

                Third.Data.TempIntList = Lorder.RandomList(Third.Data.TempStringList.Count, 12 - Third.Data.SecondSpecial.Count);

                for (int i = 0; i < Third.Data.TempIntList.Count; i++)
                {
                    Third.Data.SecondAward.Add(Third.Data.TempStringList[Third.Data.TempIntList[i]]);
                }

                Third.Data.SecondAward = Lorder.RandomPosition(Third.Data.SecondAward);

                label7.Text = "";
                label8.Text = "";
                for (int i = 0; i < 6; i++)
                {
                    if (i == 0) label7.Text = label7.Text + Third.Data.SecondAward[i] + Interval;
                    else if ((i + 1) % 3 == 0 && i != 5)
                    {
                        label7.Text = label7.Text + Third.Data.SecondAward[i] + "\n";
                    }
                    else if (i == 5)
                    {
                        label7.Text = label7.Text + Third.Data.SecondAward[i];
                    }
                    else label7.Text = label7.Text + Third.Data.SecondAward[i] + Interval;
                    
                }
                for (int i = 6; i < 12; i++)
                {
                    if (i == 6) label8.Text = label8.Text + Third.Data.SecondAward[i] + Interval;
                    else if ((i + 1) % 3 == 0 && i != 11)
                    {
                        label8.Text = label8.Text + Third.Data.SecondAward[i] + "\n";
                    }
                    else if (i == 5)
                    {
                        label8.Text = label8.Text + Third.Data.SecondAward[i];
                    }
                    else label8.Text = label8.Text + Third.Data.SecondAward[i] + Interval;
                }

                #endregion

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
                label5.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshShowBox();
        }


    }
}
