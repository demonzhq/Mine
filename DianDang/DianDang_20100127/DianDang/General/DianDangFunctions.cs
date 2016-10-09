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

        public static PawnSpan GetPawnSpan(DateTime iStartDate, DateTime iEndDate, FeeType iFeeType, PeridType iPeridType)
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

            int[] CountValue = CaculateCountDays(Result.Days, Result.Months);

            switch (iPeridType)
            {
                case PeridType.Within:
                    switch (iFeeType)
                    {
                        case FeeType.ServiceFee:
                            switch ((int)(MainForm.CountDayMode / 2))
                            {
                                case 0:
                                    Result.CountDays = CountValue[0];
                                    Result.Months += CountValue[1];
                                    break;
                                case 1:
                                    Result.CountDays = Result.Days;
                                    break;
                            }
                            break;
                        case FeeType.InterestFee:
                            switch ((int)(MainForm.CountDayMode / 2))
                            {
                                case 0:
                                    Result.CountDays = CountValue[0];
                                    Result.Months += CountValue[1];
                                    break;
                                case 1:
                                    Result.CountDays = Result.Days;
                                    break;
                            }
                            break;
                    }
                    break;
                case PeridType.Overdue:
                    switch (iFeeType)
                    {
                        case FeeType.ServiceFee:
                            switch ((int)(MainForm.CountDayMode % 2))
                            {
                                case 0:
                                    Result.CountDays = CountValue[0];
                                    Result.Months += CountValue[1];
                                    break;
                                case 1:
                                    Result.CountDays = Result.Days;
                                    break;
                            }
                            break;
                        case FeeType.InterestFee:
                            switch ((int)(MainForm.CountDayMode % 2))
                            {
                                case 0:
                                    Result.CountDays = CountValue[0];
                                    Result.Months += CountValue[1];
                                    break;
                                case 1:
                                    Result.CountDays = Result.Days;
                                    break;
                            }
                            break;
                    }
                    break;
            }

            /*
            switch ((int)(MainForm.CountDayMode / 2))
            {
                case 0:

                    break;
                case 1:
                    Result.CountDays = Result.Days;
                    break;
            }
            */

            #endregion


            //计算整个天数

            Result.CountDaysAll = Result.Months * 30 + Result.CountDays;

            Result.DaysAll = EndDate.Subtract(StartDate).Days;


            return Result;

        }

        private static int[] CaculateCountDays(double iDays, double iMonths)
        {
            int[] Result = new int[2];
            Result[0] = 0; Result[1] = 0;
            if (iDays == 0)
            {
                Result[0] = 0;
            }
            else if (iDays <= 5)
            {
                Result[0] = 5;
            }
            else if (iDays <= 15)
            {
                Result[0] = 15;
            }
            else
            {
                Result[0] = 0;
                Result[1] = 1;
            }

            if (iMonths == 0 && iDays == 0)
            {
                Result[0] = 5;
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


    enum FeeType
    {
        ServiceFee = 1,
        InterestFee = 2
    }

    enum PeridType
    {
        Within = 1,
        Overdue = 2
    }

}
