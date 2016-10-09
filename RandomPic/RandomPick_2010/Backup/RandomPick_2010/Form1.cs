using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RandomPick_2010
{
    public partial class Form1 : Form
    {
        int Step = 3;
        bool isFinishedFirst = false;
        bool isFinishedSecond = false;
        bool isFinishedThird = false;
        bool isRolledFirst = false;
        bool isRolledSecond = false;
        bool isRolledthird = false;
        bool isRolling = false;
        Loader Data = new Loader();

        public Form1()
        {
            InitializeComponent();
            if (!Data.ReadConfig())
            {
                this.Dispose();
                Application.Exit();
            }
            RefreshView();
        }

        private void RefreshView()
        {
            switch (Step)
            {
                case 3:
                    lblAwardName.Text = "三等奖候选:";
                    RefreshRoll();
                    if (isFinishedThird)
                    {
                        lblRoll.Hide();
                    }
                    else
                    {
                        lblRoll.Show();
                    }
                    break;
                case 2:
                    lblAwardName.Text = "二等奖候选:";
                    RefreshRoll();
                    if (isFinishedSecond)
                    {
                        lblRoll.Hide();
                    }
                    else
                    {
                        lblRoll.Show();
                    }
                    break;
                case 1:
                    lblAwardName.Text = "一等奖候选:";
                    RefreshRoll();
                    if (isFinishedFirst)
                    {
                        lblRoll.Hide();
                    }
                    else
                    {
                        lblRoll.Show();
                    }
                    break;
            }
        }

        private void lblNextPage_Click(object sender, EventArgs e)
        {
            if (!isRolling)
            {
                switch (Step)
                {
                    case 3:
                        if (isRolledthird)
                        {
                            SaveResult();
                        }
                        Step = 2;
                        RefreshView();
                        break;
                    case 2:
                        if (isRolledSecond)
                        {
                            SaveResult();
                        }
                        Step = 1;
                        RefreshView();
                        break;
                }
            }
        }

        private void lblPrePage_Click(object sender, EventArgs e)
        {
            if (!isRolling)
            {
                switch (Step)
                {
                    case 2:
                        if (isRolledSecond)
                        {
                            SaveResult();
                        }
                        Step = 3;
                        RefreshView();
                        break;
                    case 1:
                        if (isRolledFirst)
                        {
                            SaveResult();
                        }
                        Step = 2;
                        RefreshView();
                        break;
                }
            }

        }

        private void lblRoll_Click(object sender, EventArgs e)
        {
            if (isRolling == false)
            {
                timer2.Start();
            }
            else if (isRolling)
            {
                isRolling = false;
                timer1.Stop();
                timer2.Stop();
                switch (Step)
                {
                    case 3:
                        isRolledthird = true;
                        break;
                    case 2:
                        isRolledSecond = true;
                        break;
                    case 1:
                        isRolledFirst = true;
                        break;
                }
                lblRoll.Text = "开始抽奖";
            }
         
        }

        private void RollOnce()
        {
            Random Seed = new Random();
            int RandomIndex = 0;
            switch (Step)
            {
                case 3:
                    Data.Third.Clear();
                    for (int i = 0; i < Data.NumberOfThird; i++)
                    {
                        RandomIndex = Seed.Next(0, Data.All.Count);
                        while (Data.isInList(RandomIndex) != 0)
                        {
                            RandomIndex = Seed.Next(0, Data.All.Count);
                        }
                        Data.Third.Add(RandomIndex);
                    }
                    RefreshRoll();
                    break;
                case 2:
                    Data.Second.Clear();
                    for (int i = 0; i < Data.NumberOfSecond; i++)
                    {
                        RandomIndex = Seed.Next(0, Data.All.Count);
                        while (Data.isInList(RandomIndex) != 0)
                        {
                            RandomIndex = Seed.Next(0, Data.All.Count);
                        }
                        Data.Second.Add(RandomIndex);
                    }
                    RefreshRoll();
                    break;
                case 1:
                    Data.First.Clear();
                    for (int i = 0; i < Data.NumberOfFirst; i++)
                    {
                        RandomIndex = Seed.Next(0, Data.All.Count);
                        while (Data.isInList(RandomIndex) != 0)
                        {
                            RandomIndex = Seed.Next(0, Data.All.Count);
                        }
                        Data.First.Add(RandomIndex);
                    }
                    RefreshRoll();
                    break;
            }
        }

        private void SaveResult()
        {
            switch (Step)
            {
                case 3:
                    isFinishedThird = true;
                    break;
                case 2:
                    isFinishedSecond = true;
                    break;
                case 1:
                    isFinishedFirst = true;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RollOnce();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!isRolling)
            {
                isRolling = true;
                timer1.Start();
                lblRoll.Text = "停";
            }
            
        }

        private void RefreshRoll()
        {
            lblResult.Text = "";
            switch (Step)
            {
                case 3:
                    for (int i = 0; i < Data.Third.Count; i++)
                    {
                        lblResult.Text += Data.All[Data.Third[i]];
                        lblResult.Text += "\r\n";
                    }
                    break;
                case 2:
                    for (int i = 0; i < Data.Second.Count; i++)
                    {
                        lblResult.Text += Data.All[Data.Second[i]];
                        lblResult.Text += "\r\n";
                    }
                    break;
                case 1:
                    for (int i = 0; i < Data.First.Count; i++)
                    {
                        lblResult.Text += Data.All[Data.First[i]];
                        lblResult.Text += "\r\n";
                    }
                    break;                    
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        

    }
}
