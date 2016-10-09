using System;
using System.Collections.Generic;
using System.Text;

namespace DianDang
{
    class DianDangFunction
    {
        public static double myRound(double d, int dec)
        {
            return Math.Round(d, dec, MidpointRounding.AwayFromZero);            
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
            if (EndDate.Month != 1)
            {
                LastMonthDay = CaculateDaysByMonth(EndDate.Year, EndDate.Month - 1);
            }
            else
            {
                LastMonthDay = CaculateDaysByMonth(EndDate.Year, 12);
            }


            Result.Months = (EndDate.Month - StartDate.Month) + (EndDate.Year - StartDate.Year) * 12;


            if (StartDate.Day != DateTime.DaysInMonth(StartDate.Year, StartDate.Month) || EndDate.Day != DateTime.DaysInMonth(EndDate.Year, EndDate.Month))
            {
                if (EndDate.Day < StartDate.Day)
                {
                    Result.Days = LastMonthDay - StartDate.Day + EndDate.Day;
                    Result.Months = Result.Months - 1;
                }
                else
                {
                    Result.Days = EndDate.Day - StartDate.Day;
                }
            }


            #region CountDays 计算

            switch (MainForm.CountDayMode)
            {
                case 0:
                    if (Result.Days == 0)
                    {
                        Result.CountDays = 0;
                    }
                    else if (Result.Days <= 5)
                    {
                        Result.CountDays = 5;
                    }
                    else if (Result.Days <= 10)
                    {
                        Result.CountDays = 10;
                    }
                    else if (Result.Days <= 15)
                    {
                        Result.CountDays = 15;
                    }
                    else if (Result.Days <= 20)
                    {
                        Result.CountDays = 20;
                    }
                    else if (Result.Days <= 25)
                    {
                        Result.CountDays = 25;
                    }
                    else
                    {
                        Result.CountDays = 0;
                        Result.Months++;
                    }

                    if (Result.Months == 0 && Result.Days == 0)
                    {
                        Result.CountDays = 5;
                    }
                    break;
                case 1:
                    Result.CountDays = Result.Days;
                    break;
            }

            #endregion


            //计算整个天数

            Result.CountDaysAll = Result.Months * 30 + Result.CountDays;

            Result.DaysAll = EndDate.Subtract(StartDate).Days;


            return Result;

        }

        private static int CaculateDaysByMonth(int iYear, int iMonth)
        {
            int Result = 0;

            switch (iMonth)
            {
                case 1:
                    Result = 31;
                    break;
                case 2:
                    if (DateTime.IsLeapYear(iYear))
                    {
                        Result = 29;
                    }
                    else Result = 28;
                    break;
                case 3:
                    Result = 31;
                    break;
                case 4:
                    Result = 30;
                    break;
                case 5:
                    Result = 31;
                    break;
                case 6:
                    Result = 30;
                    break;
                case 7:
                    Result = 31;
                    break;
                case 8:
                    Result = 31;
                    break;
                case 9:
                    Result = 30;
                    break;
                case 10:
                    Result = 31;
                    break;
                case 11:
                    Result = 30;
                    break;
                case 12:
                    Result = 31;
                    break;
            }

            return Result;


        }

        public static string ChangeDateFormat(string OldDate)
        {
            string NewDate = "";
            string Sub = "";
            for (int i = 0; i < OldDate.Length; i++)
            {
                Sub = OldDate.Substring(i, 1);
                if (Sub != "/")
                {
                    NewDate = NewDate + Sub;
                }
                else NewDate = NewDate + "-";
            }
            return NewDate;
        }
    }

    

    class PawnSpan
    {
        public double Months;
        public double Days;
        public double CountDays;
        public double CountDaysAll;
        public double DaysAll;
    }

}
