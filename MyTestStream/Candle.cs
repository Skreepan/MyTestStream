using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestStream
{
    internal class Candle
    {
        private static readonly NumberFormatInfo _format = new NumberFormatInfo { NumberDecimalSeparator = "." };
        public double timeOpen { get; set; }
        public decimal open { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public decimal close { get; set; }
        public decimal volume { get; set; }
        public double timeClose { get; set; }
        public decimal quoteVolume { get; set; }
        public int numOfTrades { get; set; }
        public decimal buyBaseVolume { get; set; }
        public decimal buyQuoteVolume { get; set; }

        public decimal ignore { get; set; }

        public Candle(object[] candle)
        {
            //
            timeOpen = (long)candle[0];
            open = Decimal.Parse((string)candle[1], _format);
            high = Decimal.Parse((string)candle[2], _format);
            low = Decimal.Parse((string)candle[3], _format);
            close = Decimal.Parse((string)candle[4], _format);
            volume = Decimal.Parse((string)candle[5], _format);
            quoteVolume = Decimal.Parse((string)candle[7], _format);
            timeClose = (long)candle[6];
        }
    }
}
