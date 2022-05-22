using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestStream
{
    internal class DataKline
    {
        /// <summary>
        /// Kline start time
        /// </summary>
        public double t { get; set; }
        /// <summary>
        /// Kline close time
        /// </summary>
        public double T { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string s { get; set; }
        /// <summary>
        /// Interval
        /// </summary>
        public string i { get; set; }
        /// <summary>
        /// First trade ID
        /// </summary>
        public double f { get; set; }
        /// <summary>
        /// Last trade ID
        /// </summary>
        public double L { get; set; }
        /// <summary>
        /// Open price
        /// </summary>
        public decimal o { get; set; }
        /// <summary>
        /// Close price
        /// </summary>
        public decimal c { get; set; }
        /// <summary>
        /// High price
        /// </summary>
        public decimal h { get; set; }
        /// <summary>
        /// Low price
        /// </summary>
        public decimal l { get; set; }
        /// <summary>
        /// Base asset volume
        /// </summary>
        public double v { get; set; }
        /// <summary>
        /// Number of trades
        /// </summary>
        public double n { get; set; }
        /// <summary>
        /// Is this kline closed?
        /// </summary>
        public bool x { get; set; }
        /// <summary>
        /// Quote asset volume
        /// </summary>
        public decimal q { get; set; }
        /// <summary>
        /// Taker buy base asset volume
        /// </summary>
        public decimal V { get; set; }
        /// <summary>
        /// Taker buy quote asset volume
        /// </summary>
        public decimal Q { get; set; }
        /// <summary>
        /// Ignore
        /// </summary>
        public decimal B { get; set; }
    }
}
