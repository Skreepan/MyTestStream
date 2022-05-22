using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestStream
{
    class Order
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string s { get; set; }
        /// <summary>
        /// Client Order Id
        /// </summary>
        public string c { get; set; }
        /// <summary>
        /// Side
        /// </summary>
        public string S { get; set; }
        /// <summary>
        /// Order Type
        /// </summary>
        public string o { get; set; }
        /// <summary>
        /// Time in Force
        /// </summary>
        public string f { get; set; }
        //ToDo: сомнительный тип данных
        /// <summary>
        /// Original Quantity
        /// </summary>
        public double q { get; set; }
        /// <summary>
        /// Original Price
        /// </summary>
        public decimal p { get; set; }
        /// <summary>
        /// Average Price
        /// </summary>
        public decimal ap { get; set; }
        /// <summary>
        /// Stop Price. Please ignore with TRAILING_STOP_MARKET order
        /// </summary>
        public decimal sp { get; set; }
        /// <summary>
        /// Execution Type
        /// </summary>
        public string x { get; set; }
        /// <summary>
        /// Order Status
        /// </summary>
        public string X { get; set; }
        /// <summary>
        /// Order Id
        /// </summary>
        public long i { get; set; }
        /// <summary>
        /// Order Last Filled Quantity
        /// </summary>
        public double l { get; set; }
        /// <summary>
        /// Order Filled Accumulated Quantity
        /// </summary>
        public double z { get; set; }
        /// <summary>
        /// Last Filled Price
        /// </summary>
        public decimal L { get; set; }
        /// <summary>
        /// Commission Asset, will not push if no commission
        /// </summary>
        public string N { get; set; }
        /// <summary>
        /// Commission, will not push if no commission
        /// </summary>
        public decimal n { get; set; }
        /// <summary>
        /// Order Trade Time
        /// </summary>
        public double T { get; set; }
        /// <summary>
        /// Trade Id
        /// </summary>
        public double t { get; set; }
        /// <summary>
        /// Bids Notional
        /// </summary>
        public decimal b { get; set; }
        /// <summary>
        /// Ask Notional
        /// </summary>
        public decimal a { get; set; }
        /// <summary>
        /// Is this trade the maker side?
        /// </summary>
        public bool m { get; set; }
        /// <summary>
        /// Is this reduce only
        /// </summary>
        public bool R { get; set; }
        /// <summary>
        /// Stop Price Working Type
        /// </summary>
        public string wt { get; set; }
        /// <summary>
        /// Original Order Type
        /// </summary>
        public string ot { get; set; }
        /// <summary>
        /// Position Side
        /// </summary>
        public string ps { get; set; }
        /// <summary>
        /// If Close-All, pushed with conditional order
        /// </summary>
        public bool cp { get; set; }
        /// <summary>
        /// Activation Price, only puhed with TRAILING_STOP_MARKET order
        /// </summary>
        public decimal AP { get; set; }
        /// <summary>
        /// Callback Rate, only puhed with TRAILING_STOP_MARKET order
        /// </summary>
        public decimal cr { get; set; }
        /// <summary>
        /// ignore
        /// </summary>
        public bool pP { get; set; }
        /// <summary>
        /// ignore
        /// </summary>
        public int si { get; set; }
        /// <summary>
        /// ignore
        /// </summary>
        public int ss { get; set; }
        /// <summary>
        /// Realized Profit of the trade
        /// </summary>
        public decimal rp { get; set; }
    }
}
