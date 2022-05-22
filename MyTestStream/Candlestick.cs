using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestStream
{
    internal class Candlestick
    {
        /// <summary>
        /// Event type
        /// </summary>
        public string e { get; set; }
        /// <summary>
        /// Event time
        /// </summary>
        public double E { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string s { get; set; }
        /// <summary>
        /// Data Kline
        /// </summary>
        public DataKline k { get; set; }
    }
}
