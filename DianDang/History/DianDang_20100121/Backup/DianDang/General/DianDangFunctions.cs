using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;  
using System.Xml;  
using System.Data;  

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
            CountEndDate = CountEndDate.AddMonths(Convert.ToInt32(Result.Months));
            CountEndDate = CountEndDate.AddDays(Convert.ToInt32(Result.CountDays));
            Result.CountDaysAll = CountEndDate.Subtract(StartDate).Days;


            if (StartDate.Day == EndDate.Day)
            {
                Result.DaysAll = Result.Months * 30;
            }
            else
            {
                Result.DaysAll = EndDate.Subtract(StartDate).Days;
            }


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
