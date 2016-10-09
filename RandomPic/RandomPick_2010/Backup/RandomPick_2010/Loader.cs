using System;
using System.Collections.Generic;
using System.Text;
using MSExcel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Windows.Forms;

namespace RandomPick_2010
{
    public class Loader
    {
        public int NumberOfFirst = 0;
        public int NumberOfSecond = 0;
        public int NumberOfThird = 0;

        public List<string> All;
        public List<int> First;
        public List<int> Second;
        public List<int> Third;

        public Loader()
        {
            All = new List<string>();
            First = new List<int>();
            Second = new List<int>();
            Third = new List<int>();
        }

        public bool ReadConfig()
        {
            try
            {
                int i = 0;
                MSExcel.Application excelApp; //Excel应用程序变量
                MSExcel.Workbook excelDoc; //Excel文档变量
                excelApp = new MSExcel.ApplicationClass();  //初始化
                //由于使用的是COM库，因此有许多变量需要用Nothing代替
                Object Nothing = Missing.Value;
                excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\Config.xls", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];
                MSExcel.Range r;

                //读取All
                i = 2;
                r = ws.get_Range("A" + 2, "A" + 2);
                while (r.Text.ToString() != "")
                {
                    All.Add(r.Text.ToString());
                    i++;
                    r = ws.get_Range("A" + i, "A" + i);
                }

                //读取一等奖数目
                r = ws.get_Range("B" + 2, "B" + 2);
                NumberOfFirst = Convert.ToInt32(r.Text.ToString());

                //读取二等奖数目
                r = ws.get_Range("C" + 2, "C" + 2);
                NumberOfSecond = Convert.ToInt32(r.Text.ToString());

                //读取三等奖数目
                r = ws.get_Range("D" + 2, "D" + 2);
                NumberOfThird = Convert.ToInt32(r.Text.ToString());

                excelApp.Quit();
                if (!CheckConfig())
                {
                    MessageBox.Show("配置文件数值输入错误");
                    return false;
                }

                return true;
            }
            catch
            {
                MessageBox.Show("请给放入正确的配置文件");
                return false;
            }
            
        }

        private bool CheckConfig()
        {
            if (All.Count == 0 || NumberOfFirst == 0 || NumberOfSecond == 0 || NumberOfThird == 0)
            {
                return false;
            }
            if ((First.Count + Second.Count + Third.Count) > All.Count)
            {
                return false;
            }
            return true;
        }

        public int isInList(string iName)
        {
            int iIndex = -1;
            for (int i = 0; i < All.Count; i++)
            {
                if (All[i] == iName)
                {
                    iIndex = i;
                }
            }
            if (iIndex == -1) return -1;

            for (int i = 0; i < Third.Count; i++)
            {
                if (Third[i] == iIndex)
                {
                    return 3;
                }
            }

            for (int i = 0; i < Second.Count; i++)
            {
                if (Second[i] == iIndex)
                {
                    return 2;
                }
            }

            for (int i = 0; i < First.Count; i++)
            {
                if (First[i] == iIndex)
                {
                    return 1;
                }
            }
            return 0;

        }

        public int isInList(int iIndex)
        {
            for (int i = 0; i < Third.Count; i++)
            {
                if (Third[i] == iIndex)
                {
                    return 3;
                }
            }

            for (int i = 0; i < Second.Count; i++)
            {
                if (Second[i] == iIndex)
                {
                    return 2;
                }
            }

            for (int i = 0; i < First.Count; i++)
            {
                if (First[i] == iIndex)
                {
                    return 1;
                }
            }
            return 0;

        }


    }
}
