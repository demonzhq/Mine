using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StockAnalyzer
{
    public enum SignalStragetyType
    {
        NoStragety = 0,
        短期均线涨破长期均线 = 1,
        短期均线跌破长期均线 = 2,
    }


    public partial class StockData
    {
        public List<SignalStragetyType> GetStragety(DateTime iDate)
        {
            List<SignalStragetyType> SignalStragetyList = new List<SignalStragetyType>();

            DataOfDay Data = (DataOfDay)this.DataList[iDate.ToShortDateString()];

            int Index = this.GetIndexByDate(iDate);
           
            if (Index >= 0)
            {
                //bool isWithin = this.IsWithinPrecent((Index - 1), 10, 0.05, PriceType.ClosePrice);
                double ShortTermValue = GetAveragePriceByDay((Index - 1), MainForm.ShortTerm, PriceType.ClosePrice);
                double LongTermValue = GetAveragePriceByDay((Index - 1), MainForm.LongTerm, PriceType.ClosePrice);
                if (ShortTermValue > LongTermValue && ShortTermValue != -1 && LongTermValue != -1)
                {
                    SignalStragetyList.Add(SignalStragetyType.短期均线涨破长期均线);
                } 
                else if (ShortTermValue < LongTermValue && ShortTermValue != -1 && LongTermValue != -1)
                {
                    SignalStragetyList.Add(SignalStragetyType.短期均线跌破长期均线);
                }
            }



            return SignalStragetyList;
        }

    }


    public partial class WareHouse
    {
        public void OperationWareHouse(DateTime iDate)
        {
            this.GetSignalList(iDate);


            foreach (DictionaryEntry DE in this.StockSignalList)
            {
                StockData Stock = (StockData)this.AllStock.StockList[DE.Key];
                List<SignalStragetyType> SignalList = (List<SignalStragetyType>)DE.Value;
                
                {
                    switch (SignalList.Count)
                    {
                        case 1:
                            if (SignalList[0] == SignalStragetyType.短期均线跌破长期均线)
                            {
                                this.SellStock(iDate, Stock, PriceType.ClosePrice, SignalList);

                            }
                            else if (SignalList[0] == SignalStragetyType.短期均线涨破长期均线)
                            {
                                this.BuyStock(iDate, Stock, PriceType.ClosePrice, SignalList);
                            }
                            break;
                    }
                }

            }

        }
    }
}
