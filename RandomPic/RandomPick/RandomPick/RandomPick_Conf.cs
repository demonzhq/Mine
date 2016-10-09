using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace RandomPick
{

    public partial class RandomPick_Conf : Form
    {
        public int Num_ALL;
        public int Num_Hit;
        public ArrayList HitList = new ArrayList();
        public ArrayList AllList = new ArrayList();
        
        public RandomPick_Conf()
        {
            InitializeComponent();
        }

        private void AutoComplete_Click(object sender, EventArgs e)
        {
            int i;
            this.NumList_Input.Text = "";
            for (i = Convert.ToInt32(numericUpDown1.Value); i <= Convert.ToInt32(numericUpDown2.Value); i++)
            {
                this.NumList_Input.Text = this.NumList_Input.Text + i.ToString();
                this.NumList_Input.Text = this.NumList_Input.Text + System.Environment.NewLine;
            }
        }

        private bool CreateHit()
        {
            HitList.Clear();
            string TempNum = "";
            int isSucess = 0;
            int nowpoint = 0;
            string Error = "";
            int FinalNum = 0;
            while (nowpoint < this.MustHit_Input.Text.Length)
            {
                TempNum = "";
                while (nowpoint < this.MustHit_Input.Text.Length && this.MustHit_Input.Text.Substring(nowpoint, 1) != "\r")
                {
                    TempNum = TempNum + this.MustHit_Input.Text.Substring(nowpoint, 1);
                    nowpoint ++;
                }
                if (TempNum != "")
                {
                    try
                    {
                        FinalNum = Convert.ToInt32(TempNum);
                        HitList.Add(FinalNum);
                    }
                    catch
                    {
                        isSucess++;
                        Error = "必中输入数字有误\n";
                        Error = Error + "第" + (HitList.Count + isSucess).ToString() + "个输入不正确";
                        MessageBox.Show(Error);                        
                    }
                }
                nowpoint += 2;
            }
            if (isSucess == 0)
            {
                return true;
            }
            else return false;
        }

        private bool CreateAll()
        {
            AllList.Clear();
            string TempNum = "";
            int isSucess = 0;
            int nowpoint = 0;
            string Error = "";
            int FinalNum = 0;
            while (nowpoint < this.NumList_Input.Text.Length)
            {
                TempNum = "";
                while (nowpoint < this.NumList_Input.Text.Length && this.NumList_Input.Text.Substring(nowpoint, 1) != "\r")
                {
                    TempNum = TempNum + this.NumList_Input.Text.Substring(nowpoint, 1);
                    nowpoint++;
                }
                if (TempNum != "")
                {
                    try
                    {
                        FinalNum = Convert.ToInt32(TempNum);
                        AllList.Add(FinalNum);
                    }
                    catch
                    {
                        isSucess++;
                        Error = "所有号码输入数字有误\n";
                        Error = Error + "第" + (HitList.Count + isSucess).ToString() + "个输入不正确";
                        MessageBox.Show(Error);
                    }
                }
                nowpoint += 2;
            }
            if (isSucess == 0)
            {
                return true;
            }
            else return false;
        }
        
        private void GoPick_Click(object sender, EventArgs e)
        {
            if (this.CreateHit() && this.CreateAll())
            {
                if (HitList.Count > 8)
                {
                    MessageBox.Show("最多只能有8个必中号码");
                }
                else if (AllList.Count >= 8)
                {
                    this.Hide();
                    RunPick thisPick = new RunPick(HitList, AllList);
                }
                else MessageBox.Show("最少需要有8张选票");
            }
        }




    }
}
