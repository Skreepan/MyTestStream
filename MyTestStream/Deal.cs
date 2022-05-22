using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestStream
{
    internal abstract class Deal
    {
        public abstract void setOrderInfo(Order order);
        public abstract void resetProperty();

        public abstract void setCoinName(string name);

        public abstract void placeToSL();

        public abstract void placeToTP();
        public abstract void newStopOrder();
    }
}
