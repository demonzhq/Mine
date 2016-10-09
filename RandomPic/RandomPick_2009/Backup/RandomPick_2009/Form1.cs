using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RandomPick_2009
{
    public partial class Form1 : Form
    {
        List<string> ShowList = new List<string>();
        List<string> TotalList = new List<string>();
        public Lorder Data = new Lorder();
        Form2 Second;
        string Interval = "   ";
        

        public Form1()
        {
            

            TotalList = Data.All;
            
            InitializeComponent();
            label5.Visible = false;

            Second = new Form2(this);
            Second.Hide();

        }

        private void ReflashShowBox()
        {
            ShowList.Clear();
            List<int> RandPos = new List<int>();
            RandPos = Lorder.RandomList(TotalList.Count, 30);
            for (int i = 0; i < 30; i++)
            {
                ShowList.Add(TotalList[RandPos[i]]);
            }
            label2.Text = "";
            for (int i = 0; i < 30; i++)
            {
                if (i == 0) label2.Text = label2.Text + TotalList[RandPos[i]] + Interval;
                else if ((i + 1) % 5 == 0 && i != 29)
                {
                    label2.Text = label2.Text + TotalList[RandPos[i]] + "\n";
                }
                else if (i == 29)
                {
                    label2.Text = label2.Text + TotalList[RandPos[i]];
                }
                else label2.Text = label2.Text + TotalList[RandPos[i]] + Interval;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (label3.Text == "开始！")
            {
                ReflashShowBox();
                timer1.Start();
                timer2.Start();
                    
            }
            if (label3.Text == "停！")
            {
                timer1.Stop();
                timer2.Start();

                #region 二、三等奖


                Data.TempStringList = new List<string>();
                Data.TempIntList = new List<int>();
                Data.SecondAward.Clear();
                Data.ThirdAward.Clear();

                


                for (int i = 0; i < Data.Special2.Count; i++)
                {
                    Data.SecondAward.Add(Data.Special2[i]);
                }
                for (int i = 0; i < Data.UnUsed.Count; i++)
                {
                    Data.TempStringList.Add(Data.UnUsed[i]);
                }

                for (int i = 0; i < Data.Special1.Count; i++)
                {
                    Data.TempStringList.Remove(Data.Special1[i]);
                }

                for (int i = 0; i < Data.Special2.Count; i++)
                {
                    Data.TempStringList.Remove(Data.Special2[i]);
                }

                Data.TempIntList = Lorder.RandomList(Data.TempStringList.Count, (42 - Data.SecondAward.Count));

                for (int i = 0; i < Data.TempIntList.Count; i++)
                {
                    Data.SecondAward.Add(Data.TempStringList[Data.TempIntList[i]]);
                }

                Data.SecondAward = Lorder.RandomPosition(Data.SecondAward);



                for (int i = 41; i > 11; i--)
                {
                    Data.ThirdAward.Add(Data.SecondAward[i]);
                    Data.SecondAward.RemoveAt(i);
                }


                //生成SecondSpecial
                Data.TempStringList.Clear();
                for (int i = 0; i < Data.Special2.Count; i++)
                {
                    Data.TempStringList.Add(Data.Special2[i]);
                }

                for (int i = 0; i < Data.ThirdAward.Count; i++)
                {
                    if (Data.TempStringList.Contains(Data.ThirdAward[i]))
                    {
                        Data.TempStringList.Remove(Data.ThirdAward[i]);
                    }
                }
                Data.SecondSpecial = Data.TempStringList;
                #endregion


                label2.Text = "";
                for (int i = 0; i < 30; i++)
                {
                    if (i == 0) label2.Text = label2.Text + Data.ThirdAward[i] + Interval;
                    else if ((i + 1) % 5 == 0 && i != 29)
                    {
                        label2.Text = label2.Text + Data.ThirdAward[i] + "\n";
                    }
                    else if (i == 29)
                    {
                        label2.Text = label2.Text + Data.ThirdAward[i];
                    }
                    else label2.Text = label2.Text + Data.ThirdAward[i] + Interval;
                }

                label5.Visible = true;
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ReflashShowBox();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label3.Text == "开始！")
            {
                label3.Text = "停！";
                timer2.Stop();
            }
            else if (label3.Text == "停！")
            {
                label3.Text = "开始！";
                timer2.Stop();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Data.ThirdAward.Count; i++)
            {
                Data.UnUsed.Remove(Data.ThirdAward[i]);
            }
            this.Hide();
            this.label3.Visible = false;
            Second.Show();
        }

    }
}
