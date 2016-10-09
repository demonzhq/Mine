using System;
using System.Collections.Generic;
using System.Text;

namespace DianDang
{
    class DianDangFunction
    {
        public static double myRound(double d, int dec)
        {
            return Math.Round(d, dec - 1, MidpointRounding.AwayFromZero);            
        }
    }
}
