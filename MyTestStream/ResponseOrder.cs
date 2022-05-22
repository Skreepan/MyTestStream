using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestStream
{
    internal class ResponseOrder
    {
        public string clientOrderId { get; set; }
        public double cumQty { get; set; }
        public double cumQuote { get; set; }
        public double executedQty { get; set; }
        public double orderId {get;set;}
        public decimal avgPrice { get; set; }
        public decimal origQty { get; set; }
        public decimal price { get; set; }
        public bool reduceOnly { get; set; }
        public string side { get; set; }
        public string positionSide { get; set; }
        public string status { get; set; }
        public decimal stopPrice { get; set; }        // please ignore when order type is TRAILING_STOP_MARKET
        public bool closePosition { get; set; }  // if Close-All
        public string symbol { get; set; }
        public string timeInForce { get; set; }
        public string type { get; set; }
        public string origType { get; set; }
        public decimal activatePrice { get; set; }    // activation price, only return with TRAILING_STOP_MARKET order
        public decimal priceRate { get; set; }         // callback rate, only return with TRAILING_STOP_MARKET order
        public double updateTime { get; set; }
        public string workingType { get; set; }
        public bool priceProtect { get; set; }            // if conditional order trigger is protected   
    }
}
