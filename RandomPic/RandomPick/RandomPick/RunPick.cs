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


    public partial class RunPick : Form
    {
        private ArrayList HitList = new ArrayList();
        private ArrayList AllList = new ArrayList();
        isPickedIndex thePicked = new isPickedIndex();
        ifSeated theSeated = new ifSeated();
        ResultList Result = new ResultList();
        private int RunMode = 0;   //0-没开始, 1-随机中, 3出结果
        
        public RunPick(ArrayList theHit, ArrayList theAll)
        {
            InitializeComponent();
            this.Location = new System.Drawing.Point(0, 0);
            this.Size = new System.Drawing.Size(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width, System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height);
            this.Show();
            //this.TopMost = true;
            HitList = theHit;
            AllList = theAll;
            UpdateResult();
        }

        void RunPick_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                Application.Exit();
            }
            else if (e.KeyChar == 32 && RunMode == 1)
            {
                RunMode = 2;
                timer1.Stop();
                ShowFinal();
            }
            else if (e.KeyChar == 32 && RunMode == 2)
            {
                RunMode = 1;
                ShowRandom();
            }
            else if (e.KeyChar == 32 && RunMode == 0)
            {
                RunMode = 1;
                ShowRandom();
            }
        }

        private void UpdateResult()
        {
            label1.Text = Result.GetResult(0).ToString();
            label2.Text = Result.GetResult(1).ToString();
            label3.Text = Result.GetResult(2).ToString();
            label4.Text = Result.GetResult(3).ToString();
            label5.Text = Result.GetResult(4).ToString();
            label6.Text = Result.GetResult(5).ToString();
            label7.Text = Result.GetResult(6).ToString();
            label8.Text = Result.GetResult(7).ToString();
        }

        private void ShowRandomOnce()
        {
            int i = 0;
            int RandomSeed;
            System.Random seed = new Random();
                for (i = 0; i < 8; i++)
                {
                    RandomSeed = seed.Next(AllList.Count);
                    while (thePicked.isPicked((int)AllList[RandomSeed]))
                        RandomSeed = seed.Next(AllList.Count);
                    thePicked.addPicked((int)AllList[RandomSeed]);
                    Result.addResult((int)AllList[RandomSeed]);
                }
                UpdateResult();
                thePicked.Clear();
                Result.Clear();
        }

        private void ShowRandom()
        {
            if (RunMode == 1)
            {
                ShowRandomOnce();
                timer1.Start();
            }
        }

        void timer1_Tick(object sender, System.EventArgs e)
        {
            if (RunMode == 1)
            {
                ShowRandomOnce();
                timer1.Start();
            }
            
        }

        public void ShowFinal()
        {
            
            System.Random Seed = new Random();
            int RandomSeed = 0;
            thePicked.Clear();
            for (int i = 0; i < HitList.Count; i++)
            {
                RandomSeed = Seed.Next(8);
                while (theSeated.isSeated(RandomSeed))
                    RandomSeed = Seed.Next(8);
                theSeated.addSeated(RandomSeed);
                thePicked.addPicked((int)HitList[i]);
                Result.addResult(RandomSeed, (int)HitList[i]);
            }
            for (int i = 0; i < 8; i++)
            {
                while (!theSeated.isSeated(i))
                {
                    RandomSeed = Seed.Next(AllList.Count);
                    while (thePicked.isPicked((int)AllList[RandomSeed]) && SameHit((int)AllList[RandomSeed]))
                        RandomSeed = Seed.Next(AllList.Count);
                    thePicked.addPicked((int)AllList[RandomSeed]);
                    Result.addResult(i, (int)AllList[RandomSeed]);
                    theSeated.addSeated(i);
                }
            }
            UpdateResult();
            theSeated.Clear();
            thePicked.Clear();
            Result.Clear();
        }

        private bool SameHit(int Num)
        {
            for (int i = 0; i < 8; i++)
            {
                if (Result.GetResult(i) == Num)
                    return true;
            }
            return false;
        }

        private void StartRandom_Click(object sender, EventArgs e)
        {
            if (RunMode != 1)
            {
                RunMode = 1;
                ShowRandom();
            }
        }

        private void StopRandom_Click(object sender, EventArgs e)
        {
            if (RunMode == 1)
            {
                RunMode = 2;
                timer1.Stop();
                ShowFinal();
            }
        }

        public class isPickedIndex
        {
            public int[] PickedIndex = new int[8];
            private int Point = 0;
            public isPickedIndex()
            {
                for (int i = 0; i < 8; i++)
                {
                    PickedIndex[i] = -1;
                }
            }

            public bool isPicked(int Num)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (PickedIndex[i] == Num) return true;
                }
                return false;
            }

            public void addPicked(int Num)
            {
                if (Point >= 8)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        PickedIndex[i] = -1;
                    }
                    Point = 0;
                }
                PickedIndex[Point] = Num;
                Point++;
            }

            public void Clear()
            {
                for (int i = 0; i < 8; i++)
                {
                    PickedIndex[i] = -1;
                }
                this.Point = 0;
            }
        }

        public class ifSeated
        {
            private bool[] Seated = new bool[8];
            private int Point = 0;
            public ifSeated()
            {
                for (int i = 0; i < 8; i++)
                    Seated[i] = false;              
            }
            public void addSeated(int Num)
            {
                if (Point == 8)
                {
                    for (int i = 0; i < 8; i++)
                        Seated[i] = false;
                    Seated[Num] = true;
                    Point = 1;
                }
                else
                {
                    Seated[Num] = true;
                    Point++;
                }
            }
            public bool isSeated(int Num)
            {
                    bool result = Seated[Num];
                    return result;              
            }
            public void Clear()
            {
                for (int i = 0; i < 8; i++)
                    Seated[i] = false;
                Point = 0;
            }
        }


        public class ResultList
        {
            public int[] Result = new int[8];
            public int Point = 0;
            public ResultList()
            {
                for (int i = 0; i < 8; i++)
                {
                    Result[i] = 0;
                }
            }
            public void Clear()
            {
                this.Point = 0;
            }

            public void addResult(int Num)
            {
                Result[Point] = Num;
                Point++;
                if (Point >= 8)
                    Point = 0;
            }

            public void addResult(int Seat, int Num)
            {
                Point = 0;
                Result[Seat] = Num;
            }

            public int GetResult(int Num)
            {
                return Result[Num];
            }
        }



    }
}
