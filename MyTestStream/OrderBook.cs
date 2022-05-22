using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestStream
{
    internal class OrderBook
    {
        public long lastUpdateId { get; set; }
        public long E { get; set; }
        public long T { get; set; }
        public decimal[][] bids { get; set; }
        public decimal[][] asks { get; set; }
    }
}
