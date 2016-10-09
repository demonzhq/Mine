using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace StockAnalyzer
{
    public partial class StockData
    {
        public FileInfo DataFile;
        public string StockName = "";
        public string StockCode = "";
        public int Count = 0;
        public int Volume = 0;
        public Hashtable DataList = new Hashtable();

        public StockData()
        {
        }

        public StockData(FileInfo iDataFile)
        {
            DataFile = iDataFile;
            ReadFile();
        }

        private void ReadFile()
        {
            string Line = "";
            string[] LineData;
            StreamReader Reader = new StreamReader(DataFile.DirectoryName + @"\" + DataFile.Name, Encoding.Default);

            #region Get Title
            Line = Reader.ReadLine();
            LineData = Line.Split(' ');
            //this.StockCode = LineData[0];
            this.StockCode = DataFile.Name.Remove(DataFile.Name.Length - 4, 4);
            this.StockName = LineData[1];
            Line = Reader.ReadLine();
            #endregion

            while (Line != "" && Line != null)
            {
                try
                {
                    Line = Reader.ReadLine();
                }
                catch
                {
                    Line = "";
                }

                if (Line != "" && Line != null)
                {
                    LineData = Line.Split(';');
                    DateTime Date = DateTime.Parse(LineData[0]);
                    double Open = Convert.ToDouble(LineData[1]);
                    double Hightest = Convert.ToDouble(LineData[2]);
                    double Lowest = Convert.ToDouble(LineData[3]);
                    double Close = Convert.ToDouble(LineData[4]);
                    double Volume = Convert.ToDouble(LineData[5]);
                    double Turnover = Convert.ToDouble(LineData[6]);

                    DataOfDay Day = new DataOfDay(Date, Open, Close, Hightest, Lowest, Volume, Turnover, Count);
                    DataList.Add(Date.ToShortDateString(), Day);
                    DataList.Add(Count, Day);
                    this.Count++;
                }
            }
        }

        public override string ToString()
        {
            return (this.StockCode + "," + this.StockName);
        }

        public double GetPriceByType(DateTime iDate, PriceType iPriceType)
        {
            DataOfDay Day;
            Day = (DataOfDay)this.DataList[iDate.ToShortDateString()];
            for (int i = 1; Day == null; i++)
            {
                DateTime SearchDate = iDate;
                SearchDate = iDate.AddDays(0 - i);
                Day = (DataOfDay)this.DataList[SearchDate.ToShortDateString()];
                if (Day == null)
                {
                    SearchDate = iDate;
                    SearchDate = iDate.AddDays(i);
                    Day = (DataOfDay)this.DataList[SearchDate.ToShortDateString()];
                }
            }
            return Day.GetPriceByType(iPriceType);
        }

        public double GetAveragePriceByDay(DateTime iDate, int iDays, PriceType iPriceType)
        {
            int iIndex = this.GetIndexByDate(iDate);
            if (iIndex >= 0)
            {
                return GetAveragePriceByDay(iIndex, iDays, iPriceType);
            }
            else
                return -1;

        }

        public double GetAveragePriceByDay(int iIndex, int iDays, PriceType iPriceType)
        {
            double Result = -1;
            double Sum = 0;

            DataOfDay Day = (DataOfDay)this.DataList[iIndex];

            if (Day != null)
            {
                int MaxIndex = Day.Index;
                if (MaxIndex + 1 < iDays)
                {
                    return -1;
                }
                else
                {
                    for (int i = MaxIndex - iDays + 1; i <= MaxIndex; i++)
                    {
                        DataOfDay theDay = (DataOfDay)this.DataList[i];
                        Sum = Sum + theDay.GetPriceByType(iPriceType);
                    }
                    Result = Sum / iDays;
                    return Result;
                }
            }
            else
                return -1;

        }

        public bool IsWithinPrecent(int iIndex, int iDays, double iPrecent, PriceType iPriceType)
        {
            double Max = 0;
            double Min = 0;
            DataOfDay Day = (DataOfDay)this.DataList[iIndex];
            if (iIndex == 180)
            {
            }
            if (Day != null)
            {
                if (Day.Index + 1 < iDays)
                {
                    return false;
                }
                else
                {

                    Max = Day.GetPriceByType(iPriceType);
                    Min = Day.GetPriceByType(iPriceType);
                    for (int i = Day.Index - iDays + 1; i <= Day.Index; i++)
                    {
                        DataOfDay theDay = (DataOfDay)this.DataList[i];
                        if (theDay.GetPriceByType(iPriceType) > Max)
                        {
                            Max = theDay.GetPriceByType(iPriceType);
                        }
                        else if (theDay.GetPriceByType(iPriceType) < Min)
                        {
                            Min = theDay.GetPriceByType(iPriceType);
                        }
                    }

                    if ((Max - Min) / Day.GetPriceByType(iPriceType) < iPrecent)
                    {
                        return true;
                    }
                    else return false;
                }
            }
            return false;
        }

        public int GetIndexByDate(DateTime iDate)
        {
            DataOfDay Day = (DataOfDay)this.DataList[iDate.ToShortDateString()];
            if (Day == null)
            {
                return -1;
            }
            else
            {
                return Day.Index;
            }
        }

    }

    public class DataOfDay
    {
        public DateTime Date = new DateTime();
        public double Open = 0;
        public double Close = 0;
        public double Highest = 0;
        public double Lowest = 0;
        public double Volume = 0;
        public double Turnover = 0;
        public int Index = 0;

        public DataOfDay(DateTime iDate, double iOpen, double iClose, double iHighest, double iLowest, double iVolume, double iTurnover, int iIndex)
        {
            this.Date = iDate;
            this.Open = iOpen;
            this.Close = iClose;
            this.Highest = iHighest;
            this.Lowest = iLowest;
            this.Volume = iVolume;
            this.Turnover = iTurnover;
            this.Index = iIndex;
        }

        public DataOfDay()
        {
        }

        public override string ToString()
        {
            return (Date.ToShortDateString());
        }

        public double GetPriceByType(PriceType iPriceType)
        {
            switch (iPriceType)
            {
                case PriceType.OpenPrice:
                    return this.Open;
                case PriceType.ClosePrice:
                    return this.Close;
                case PriceType.HightestPrice:
                    return this.Highest;
                case PriceType.LowestPrice:
                    return this.Lowest;
                case PriceType.MiddlePrice:
                    return (this.Lowest + this.Highest) / 2;
                default: return -1;
            }
        }
    }

    public class StockGroup
    {
        public Hashtable StockList = new Hashtable();
        public string GroupName = "";
        public DirectoryInfo Dir;
        public string Filter = "";
        public int Count = 0;

        public StockGroup(string iGroupName, string iFilter, DirectoryInfo iDir)
        {
            this.GroupName = iGroupName;
            this.Filter = iFilter;
            this.Dir = iDir;

            FileInfo[] FileList;
            int Progress = 0;

            FileList = Dir.GetFiles(iFilter);

            int FileCount = FileList.Length;

            for (int i = 0; i < FileCount; i++)
            {
                StockData Stock = new StockData(FileList[i]);
                Progress = 100 * i / FileCount;

                this.AddStock(Stock);
            }
        }

        public StockGroup(string iGroupName)
        {
            this.GroupName = iGroupName;
        }

        public StockGroup(string iGroupName, string[] iFilter, DirectoryInfo iDir)
        {
            this.GroupName = iGroupName;
            this.Filter = iFilter[0];
            this.Dir = iDir;

            for (int i = 0; i < iFilter.Length; i++)
            {
                FileInfo[] FileList;
                int Progress = 0;

                FileList = Dir.GetFiles(iFilter[i]);

                int FileCount = FileList.Length;

                for (int j = 0; j < FileCount; j++)
                {
                    StockData Stock = new StockData(FileList[j]);
                    Progress = 100 * j / FileCount;

                    this.AddStock(Stock);
                }
            }

        }


        public override string ToString()
        {
            return (this.GroupName);
        }

        public bool AddStock(StockData iStock)
        {
            StockData Stock = (StockData)StockList[iStock.StockCode];
            if (Stock != null)
            {
                return false;
            }
            else
            {
                StockList.Add(iStock.StockCode, iStock);
                this.Count++;
                return true;
            }
        }

        public bool AddStock(StockData iStock, int iVolume)
        {
            StockData Stock = (StockData)this.StockList[iStock.StockCode];
            if (Stock !=null)
            {
                Stock.Volume += iVolume;
            }
            else
            {
                iStock.Volume = iVolume;
                this.AddStock(iStock);
            }
            return true;
        }

        public bool RemoveStock(StockData iStock)
        {
            StockData Stock = (StockData)this.StockList[iStock.StockCode];
            if (Stock == null)
            {
                return false;
            }
            else
            {
                this.StockList.Remove(iStock.StockCode);
                this.Count--;
                return true;
            }
        }

        public bool RemoveStock(StockData iStock, int iVolume)
        {
            StockData Stock = (StockData)this.StockList[iStock.StockCode];
            if (Stock == null)
            {
                return false;
            }
            else
            {
                if (Stock.Volume < iVolume)
                {
                    return false;
                }
                else
                {
                    Stock.Volume = Stock.Volume - iVolume;
                    if (Stock.Volume == 0)
                    {
                        this.RemoveStock(iStock);
                    }
                    return true;
                }
            }
        }

        public void Clear()
        {
            this.StockList.Clear();
            this.Count = 0;
        }
    }
}
