using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer
{
    public enum OperationType
    {
        Buy = 1,
        Sell = 2
    }

    public enum PriceType
    {
        OpenPrice = 1,
        ClosePrice = 2,
        HightestPrice = 3,
        LowestPrice = 4,
        MiddlePrice = 5
    }

    public enum BuyResult
    {
        Secuess = 0,
        NotEnoughCash = 1,
    }

    public enum SellResult
    {
        Sucess = 0,
        NotEnoughVolume = 1
    }
}
