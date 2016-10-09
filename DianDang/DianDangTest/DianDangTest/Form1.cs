using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DianDangTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DateTime st = new DateTime(2010,1,1);
            DateTime ed = new DateTime(2010,2,5);
            PawnSpan Span = GetPawnSpan(st, ed);
        }
        public static PawnSpan GetPawnSpan(DateTime iStartDate, DateTime iEndDate)
        {
            DateTime StartDate, EndDate;
            if (iStartDate > iEndDate)
            {
                EndDate = iStartDate;
                StartDate = iEndDate;
            }
            else
            {
                StartDate = iStartDate;
                EndDate = iEndDate;
            }

            PawnSpan Result = new PawnSpan();
            int LastMonthDay = 0;

            Result.Months = (EndDate.Month - StartDate.Month) + (EndDate.Year - StartDate.Year) * 12;

            #region 计算上月天数
            switch (EndDate.Month)
            {
                case 1: 
                    LastMonthDay = 31;
                    break;
                case 2:
                    LastMonthDay = 31;
                    break;
                case 3:
                    if (DateTime.IsLeapYear(EndDate.Year))
                    {
                        LastMonthDay = 29;
                    }
                    else LastMonthDay = 28;
                    break;
                case 4:
                    LastMonthDay = 31;
                    break;
                case 5:
                    LastMonthDay = 30;
                    break;
                case 6:
                    LastMonthDay = 31;
                    break;
                case 7:
                    LastMonthDay = 30;
                    break;
                case 8:
                    LastMonthDay = 31;
                    break;
                case 9:
                    LastMonthDay = 31;
                    break;
                case 10:
                    LastMonthDay = 30;
                    break;
                case 11:
                    LastMonthDay = 31;
                    break;
                case 12:
                    LastMonthDay = 30;
                    break;
            }
            #endregion

            if (EndDate.Day < StartDate.Day)
            {
                Result.Days = LastMonthDay - StartDate.Day + EndDate.Day;
                Result.Months = Result.Months - 1;
            }
            else
            {
                Result.Days = EndDate.Day - StartDate.Day;
            }


            if (Result.Days == 0)
            {
                Result.CountDays = 0;
            }
            else if (Result.Days <= 5)
            {
                Result.CountDays = 5;
            }
            else if (Result.Days <= 15)
            {
                Result.CountDays = 15;
            }
            else
            {
                Result.CountDays = 30;
            }

            if (Result.Months == 0 && Result.Days == 0)
            {
                Result.CountDays = 5;
            }

            

            //计算整个天数
            DateTime CountEndDate = new DateTime();
            CountEndDate = StartDate;
            CountEndDate = CountEndDate.AddMonths(Convert.ToInt32(Result.Months.ToString()));
            CountEndDate = CountEndDate.AddDays(Convert.ToInt32(Result.CountDays.ToString()));
            Result.CountDaysAll = CountEndDate.Subtract(StartDate).Days;

            Result.DaysAll = EndDate.Subtract(StartDate).Days;

            return Result;

        }
    }
}
        public class PawnSpan
{
    public double Months;
    public double Days;
    public double CountDays;
    public double CountDaysAll;
    public double DaysAll;
}

