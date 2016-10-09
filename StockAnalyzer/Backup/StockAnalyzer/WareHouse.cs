using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StockAnalyzer
{
    public class Operation
    {
        public DateTime OpDate;
        public StockData Stock;
        public double Price;
        public int Volume;
        public OperationType OpType;
        public List<SignalStragetyType> SignalList;
       

        public Operation(DateTime iOpDate, ref StockData iStock, double iPrice, int iVolume, OperationType iOpType, List<SignalStragetyType> iSignalList)
        {
            this.OpDate = iOpDate;
            this.Stock = iStock;
            this.Price = iPrice;
            this.Volume = iVolume;
            this.OpType = iOpType;
            this.SignalList = iSignalList;
        }

        public override string ToString()
        {
            string Result = "";
            Result = OpDate.ToShortDateString() + "," + OpType.ToString() + "," + Stock.ToString() + "," + Price.ToString() + "元," + Volume.ToString() + "股";
            for (int i = 0; i < SignalList.Count; i++)
            {
                Result = Result + "," + SignalList[i];
            }
            return (Result);
        }

    }

    public partial class WareHouse
    {
        double StartUpCash = 0;
        double Cash = 0;
        List<Operation> OPRecord = new List<Operation>();
        StockGroup StockInHand = new StockGroup("StockInHand");
        StockGroup AllStock = new StockGroup("AllStock");
        Hashtable StockSignalList = new Hashtable();
        DateTime SimuDate = new DateTime();
        double FeeRate = 0;
        string OPHistory = "";
        

        public WareHouse(double iCash, StockGroup iAllStock, double iFeeRate)
        {
            this.Cash = iCash;
            this.AllStock = iAllStock;
            this.StartUpCash = iCash;
            this.FeeRate = iFeeRate;
        }

        public WareHouse(double iCash, StockGroup iAllStock, StockGroup iStockInHand, double iFeeRate)
        {
            this.Cash = iCash;
            this.AllStock = iAllStock;
            this.StockInHand = iStockInHand;
            this.StartUpCash = iCash;
            this.FeeRate = iFeeRate;
        }

        public WareHouse()
        {
        }

        public double GetProperty()
        {
            double Property = Cash;
            foreach (DictionaryEntry DE in this.StockInHand.StockList)
            {
                StockData Stock = (StockData)DE.Value;
                Property = Property + Stock.Volume * Stock.GetPriceByType(this.SimuDate, PriceType.ClosePrice);
            }
            return Property;
        }

        public override string ToString()
        {
            string Result = "";
            Result = Result + this.SimuDate.ToShortDateString() + ",总资产" + GetProperty();
            return Result;
        }

        public BuyResult BuyStock(DateTime iDate, StockData iStock, double iPrice, int iVolume, List<SignalStragetyType> iSignalList)
        {
            if (Convert.ToDouble(iVolume) * iPrice * (1 + this.FeeRate) > Cash)
            {
                return BuyResult.NotEnoughCash;
            }
            else
            {
                OPRecord.Add(new Operation(iDate, ref iStock, iPrice, iVolume, OperationType.Buy, iSignalList));

                StockInHand.AddStock(iStock, iVolume);

                Cash = Cash - iPrice * Convert.ToDouble(iVolume) * (1 + this.FeeRate);

                this.OPHistory += iDate.ToShortDateString() + "," + iStock.StockName + "," + OperationType.Buy.ToString() + "," + iPrice.ToString() + "元," + iVolume.ToString() + "股,现金" + this.Cash + "元," + (this.GetProperty()/this.StartUpCash).ToString() + "倍\r\n";

                return BuyResult.Secuess;  
              
                
            }
        }

        public BuyResult BuyStock(DateTime iDate, StockData iStock, PriceType iPriceType, int iVolume, List<SignalStragetyType> iSignalList)
        {

            double iPrice = iStock.GetPriceByType(iDate, iPriceType);

            return BuyStock(iDate, iStock, iPrice, iVolume, iSignalList);
        }

        public BuyResult BuyStock(DateTime iDate, StockData iStock, double iPrice, double iCash, List<SignalStragetyType> iSignalList)
        {
            int iVolume = (int)(iCash / (1 + this.FeeRate) / iPrice);
            if (iVolume == 0)
            {
                return BuyResult.NotEnoughCash;
            }
            else
            {
                return BuyStock(iDate, iStock, iPrice, iVolume, iSignalList);
            }
        }

        public BuyResult BuyStock(DateTime iDate, StockData iStock, PriceType iPriceType, double iCash, List<SignalStragetyType> iSignalList)
        {
            double iPrice = iStock.GetPriceByType(iDate, iPriceType);
            int iVolume = (int)(iCash / (1 + this.FeeRate) / iPrice);
            if (iVolume == 0)
            {
                return BuyResult.NotEnoughCash;
            }
            else
            {
                return BuyStock(iDate, iStock, iPrice, iVolume, iSignalList);
            }
        }

        public BuyResult BuyStock(DateTime iDate, StockData iStock, double iPrice, List<SignalStragetyType> iSignalList)
        {
            if (iPrice > Cash)
            {
                return BuyResult.NotEnoughCash;
            }
            else
            {
                int iVolume = (int)(this.Cash / (1 + this.FeeRate) / iPrice);

                return BuyStock(iDate, iStock, iPrice, iVolume, iSignalList);
            }
        }

        public BuyResult BuyStock(DateTime iDate, StockData iStock, PriceType iPriceType, List<SignalStragetyType> iSignalList)
        {
            double iPrice = iStock.GetPriceByType(iDate, iPriceType);
            if (iPrice > Cash)
            {
                return BuyResult.NotEnoughCash;
            }
            else
            {
                int iVolume = (int)(this.Cash / (1 + this.FeeRate) / iPrice);

                return BuyStock(iDate, iStock, iPrice, iVolume, iSignalList);
            }
        }

        public SellResult SellStock(DateTime iDate, StockData iStock, double iPrice, int iVolume, List<SignalStragetyType> iSignalList)
        {
            if (StockInHand.RemoveStock(iStock, iVolume))
            {
                OPRecord.Add(new Operation(iDate, ref iStock, iPrice, iVolume, OperationType.Sell, iSignalList));
                this.Cash += iPrice * iVolume * (1 - this.FeeRate);
                this.OPHistory += iDate.ToShortDateString() + "," + iStock.StockName + "," + OperationType.Sell.ToString() + "," + iPrice.ToString() + "元," + iVolume.ToString() + "股,现金" + this.Cash + "元," + (this.GetProperty() / this.StartUpCash).ToString() + "倍\r\n";
                return SellResult.Sucess;
            }
            else
            {
                return SellResult.NotEnoughVolume;
            }
        }

        public SellResult SellStock(DateTime iDate, StockData iStock, PriceType iPriceType, int iVolume, List<SignalStragetyType> iSignalList)
        {
            double iPrice = iStock.GetPriceByType(iDate, iPriceType);

            return SellStock(iDate, iStock, iPrice, iVolume, iSignalList);
        }

        public SellResult SellStock(DateTime iDate, StockData iStock, double iPrice, List<SignalStragetyType> iSignalList)
        {
            StockData Stock = (StockData)this.StockInHand.StockList[iStock.StockCode];
            if (Stock != null)
            {
                int iVolume = Stock.Volume;

                return SellStock(iDate, iStock, iPrice, iVolume, iSignalList);
            }
            else
            {
                return SellResult.NotEnoughVolume;
            }
        }

        public SellResult SellStock(DateTime iDate, StockData iStock, PriceType iPriceType, List<SignalStragetyType> iSignalList)
        {
            double iPrice = iStock.GetPriceByType(iDate, iPriceType);
            StockData Stock = (StockData)this.StockInHand.StockList[iStock.StockCode];
            if (Stock != null)
            {
                int iVolume = Stock.Volume;

                return SellStock(iDate, iStock, iPrice, iVolume, iSignalList);

            }
            else
            {
                return SellResult.NotEnoughVolume;
            }
        }

        public void GetSignalList(DateTime iDate)
        {
            StockSignalList.Clear();
            foreach (DictionaryEntry DE in this.AllStock.StockList)
            {               
                StockData Stock = (StockData)DE.Value;
                List<SignalStragetyType> SignalList = Stock.GetStragety(iDate);
                if (SignalList.Count > 0)
                {
                    this.StockSignalList.Add(Stock.StockCode, SignalList);
                }
            }
        }

        public void Run(DateTime iStartDate, DateTime iEndDate)
        {
            for (DateTime Date = iStartDate; Date.ToShortDateString() != iEndDate.ToShortDateString(); Date = Date.AddDays(1))
            {
                this.SimuDate = Date;
                this.OperationWareHouse(Date);          
            }
        }

        public void Clear()
        {
            this.Cash = this.StartUpCash;
            this.StockInHand.Clear();
            this.OPRecord.Clear();
            this.OPHistory = "";
        }

    }


}
