using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using MSExcel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Windows.Forms;


namespace RandomPick_2009
{
    public class Lorder
    {
        public List<string> All = new List<string>();
        public List<string> Special1 = new List<string>();
        public List<string> Special2 = new List<string>();

        public List<string> SecondSpecial = new List<string>();
        public List<string> ThirdSpecial = new List<string>();

        public List<string> TempStringList = new List<string>();
        public List<int> TempIntList = new List<int>();
        public List<string> FirstAward = new List<string>();
        public List<string> SecondAward = new List<string>();
        public List<string> ThirdAward = new List<string>();

        public List<string> UnUsed = new List<string>();
        


        public Lorder()
        {
            if (!LordInfo()) Application.Exit();
            else
            {
                UnUsed.Clear();
                for (int i = 0; i < All.Count; i++)
                {
                    UnUsed.Add(All[i]);
                }
            }

            //GeneratRandom();
        }

        public bool LordInfo()
        {
            int i = 2;
            MSExcel.Application excelApp; //Excel应用程序变量
            MSExcel.Workbook excelDoc; //Excel文档变量
            excelApp = new MSExcel.ApplicationClass();  //初始化
            //由于使用的是COM库，因此有许多变量需要用Nothing代替
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\Info.xls", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];
            MSExcel.Range r;

            i = 2;
            r = ws.get_Range("A" + 2, "A" + 2);
            while (r.Text.ToString() != "")
            {
                All.Add(r.Text.ToString());
                i++;
                r = ws.get_Range("A" + i, "A" + i);
            }

            i = 2;
            r = ws.get_Range("B" + 2, "B" + 2);
            while (r.Text.ToString() != "")
            {
                Special1.Add(r.Text.ToString());
                i++;
                r = ws.get_Range("B" + i, "B" + i);
            }

            i = 2;
            r = ws.get_Range("C" + 2, "C" + 2);
            while (r.Text.ToString() != "")
            {
                Special2.Add(r.Text.ToString());
                i++;
                r = ws.get_Range("C" + i, "C" + i);
            }

            excelDoc.Close(Nothing, Nothing, Nothing);
            excelApp.Quit();


            if (Special1.Count > All.Count)
            {
                MessageBox.Show("大奖数量不能不全部的多");
                return false;
            }

            if (Special2.Count > All.Count)
            {
                MessageBox.Show("二、三等奖数量不能不全部的多");
                return false;
            }

            if (All.Count < 49)
            {
                MessageBox.Show("至少创建48张号码");
                return false;
            }
            return true;

        }

        public static List<int> RandomList(int Total, int Count)
        {
            int RandPosition = 0;
            Random Seed = new Random();
            List<int> Rand = new List<int>();
            List<int> Original = new List<int>();

            for (int i = 0; i < Total; i++)
            {
                Original.Add(i);
            }

            for (int j = 0; j < Count; j++)
            {
                RandPosition = Seed.Next(Original.Count);
                Rand.Add(Original[RandPosition]);
                Original.RemoveAt(RandPosition);
            }

            return Rand;
        }

        public static List<string> RandomPosition(List<string> Original)
        {

            List<string> Rand = new List<string>();
            Random Seed = new Random();
            int Length = Original.Count;
            int RandPosition = 0;
            for (int i = 0; i < Length; i++)
            {
                RandPosition = Seed.Next(Original.Count);
                Rand.Add(Original[RandPosition]);
                Original.RemoveAt(RandPosition);
            }

            return Rand;
        }

        public void GeneratRandom()
        {
            

            #region 一等奖
            TempStringList.Clear();
            TempIntList.Clear();
            FirstAward.Clear();
            for (int i = 0; i < Special1.Count; i++)
            {
                FirstAward.Add(Special1[i]);
            }

            for (int i = 0; i < UnUsed.Count; i++)
            {
                TempStringList.Add(UnUsed[i]);
            }

            for (int i = 0; i < Special2.Count; i++)
            {
                TempStringList.Remove(Special2[i]);
            }

            TempIntList =RandomList(TempStringList.Count, (6-FirstAward.Count));

            for (int i = 0; i < TempIntList.Count; i++)
            {
                FirstAward.Add(TempStringList[TempIntList[i]]);
            }

            FirstAward = RandomPosition(FirstAward);

            for (int i = 0; i < FirstAward.Count; i++)
            {
                UnUsed.Remove(FirstAward[i]);
            }
            #endregion

            #region 二、三等奖
            TempStringList.Clear();
            TempIntList.Clear();
            SecondAward.Clear();
            ThirdAward.Clear();
            for (int i = 0; i < Special2.Count; i++)
            {
                SecondAward.Add(Special2[i]);
            }
            for (int i = 0; i < UnUsed.Count; i++)
            {
                TempStringList.Add(UnUsed[i]);
            }

            TempIntList = RandomList(TempStringList.Count, (42 - SecondAward.Count));

            for (int i = 0; i < TempIntList.Count; i++)
            {
                SecondAward.Add(TempStringList[TempIntList[i]]);
            }

            SecondAward = RandomPosition(SecondAward);

            for (int i = 0; i < SecondAward.Count; i++)
            {
                UnUsed.Remove(SecondAward[i]);
            }

            for (int i = 41; i > 11; i--)
            {
                ThirdAward.Add(SecondAward[i]);
                SecondAward.RemoveAt(i);
            }

            #endregion


        }



    }
}