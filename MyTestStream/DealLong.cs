using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace MyTestStream
{
    internal class DealLong : Deal
    {
        public decimal high = 0.0m;
        public bool isRequestNewStopOrder = true;
        public bool isRequestNewStopLoss = true;
        public bool isRequestNewTakeProfit = true;
        public bool isRequestCancelOrder = true;
        public decimal averagePrice = 0.0m;
        public string ticker = "";
        public decimal sp = 0.0m;
        public bool isStop = false;
        public bool isDeal = false;
        public bool isStopLoss = false;
        public bool isTakeProfit = false;
        public string ID_STOP_ORDER= "";
        public string ID_TAKE_PROFIT_MARKET = "";
        public string ID_STOP_MARKET = "";
        private Client client;

        public DealLong(Client c)
        {
            client = c;
        }

        public void loopTrade()
        {
            high = client.high;
            if (isDeal && !isStopLoss)
            {
                placeToSL();
            }

            if (isDeal && !isTakeProfit)
            {
                placeToTP();
            }

            if (!isStop && !isDeal && isStopLoss)
            {
                cancelStopLoss();
            }

            if (!isStop && !isDeal && isTakeProfit)
            {
                cancelTakeProfit();
            }

            if (!isStop && !isDeal && !isStopLoss && !isTakeProfit)
            {
                newStopOrder();
            }
            checkIsDealShort();
            checkToHigh();
            checkDistance();
            client.form1.labelDealLongInfo.Text = $"high - {high}\n";
            client.form1.labelDealLongInfo.Text += $"isRequestNewStopOrder - {isRequestNewStopOrder}\n";
            client.form1.labelDealLongInfo.Text += $"isRequestNewStopLoss - {isRequestNewStopLoss}\n";
            client.form1.labelDealLongInfo.Text += $"isRequestNewTakeProfit - {isRequestNewTakeProfit}\n";
            client.form1.labelDealLongInfo.Text += $"averagePrice - {averagePrice}\n";
            client.form1.labelDealLongInfo.Text += $"ticker - {ticker}\n";
            client.form1.labelDealLongInfo.Text += $"sp - {sp}\n";
            client.form1.labelDealLongInfo.Text += $"isStop - {isStop}\n";
            client.form1.labelDealLongInfo.Text += $"isDeal - {isDeal}\n";
            client.form1.labelDealLongInfo.Text += $"isStopLoss - {isStopLoss}\n";
            client.form1.labelDealLongInfo.Text += $"isTakeProfit - {isTakeProfit}\n";
            client.form1.labelDealLongInfo.Text += $"ID_STOP_ORDER - {ID_STOP_ORDER}\n";
            client.form1.labelDealLongInfo.Text += $"ID_TAKE_PROFIT_MARKET - {ID_TAKE_PROFIT_MARKET}\n";
            client.form1.labelDealLongInfo.Text += $"ID_STOP_MARKET - {ID_STOP_MARKET}\n";
        }
        /// <summary>
        /// Асинхронно кидаем стоп ордер на уровень, если нет сделки и стоп ордера
        /// </summary>
        public async override void newStopOrder()
        {
            if(!isDeal && !isStop && client.getPercToHigh().CompareTo(client.getPercToSetOrder()) < 0 && isRequestNewStopOrder && !client.getLevelsHL().checkIsStabHigh() && !client.dealShort.isDeal && client.currentPrice.CompareTo(high) < 0)
            {
                isRequestNewStopOrder = false;
                ResponseOrder ro = new ResponseOrder();
                ro = await Task.Run(() => client.newStopOrderBuy());
                Thread.Sleep(500);
                if(ro !=null && ro.status == "NEW")
                {
                    sp = ro.stopPrice;
                    isStop = true;
                    ID_STOP_ORDER = ro.clientOrderId;
                    isRequestNewStopOrder = true;
                }
                await Task.Delay(2000);
                if (!isStop)
                {
                    isRequestNewStopOrder = true;
                }
            }
        }
        /// <summary>
        /// Ставим стоп лось
        /// </summary>
        public async override void placeToSL()
        {
            if(isRequestNewStopLoss && !isStopLoss && isDeal)
            {
                isRequestNewStopLoss = false;
                await Task.Run(() => client.calculStopLoss("BUY", averagePrice));
                ResponseOrder ro = await Task.Run(() => client.newStopLoss("BUY"));
                await Task.Delay(1000);
                if(ro.status == "NEW")
                {
                    ID_STOP_MARKET = ro.clientOrderId;
                    isStopLoss = true;
                    isRequestNewStopLoss = true;
                }
            }
        }

        public async override void placeToTP()
        {
            if(isRequestNewTakeProfit && !isTakeProfit && isDeal)
            {
                isRequestNewTakeProfit = false;
                await Task.Run(() => client.calculateTakeProfit("BUY", averagePrice));
                ResponseOrder ro = await Task.Run(() => client.newTakeProfit("BUY"));
                await Task.Delay(1000);
                if(ro.status == "NEW")
                {
                    ID_TAKE_PROFIT_MARKET = ro.clientOrderId;
                    isTakeProfit = true;
                    isRequestNewTakeProfit = true;
                }
            }
        }

        public override void resetProperty()
        {
            isRequestNewStopOrder = true;
            isRequestNewStopLoss = true;
            isRequestNewTakeProfit = true;
            averagePrice = 0.0m;
            sp = 0.0m;
            isStop = false;
            isDeal = false;
            //isStopLoss = false;
            //isTakeProfit = false;
            ID_STOP_ORDER = "";
            //ID_TAKE_PROFIT_MARKET = "";
            //ID_STOP_MARKET = "";
        }

        public override void setCoinName(string name)
        {
            ticker = name + "USDT";
        }

        public override void setOrderInfo(Order order)
        {
            if(order.o == "LIMIT" && order.S == "BUY" && order.x == "TRADE" && order.X == "FILLED" && ID_STOP_ORDER == order.c && order.s == ticker)
            {
                averagePrice = order.ap;
                isStop = false;
                isDeal = true;
                placeToSL();
                placeToTP();
            }

            if(ID_STOP_MARKET == order.c && order.X == "FILLED" || ID_STOP_MARKET == order.c && order.X == "CANCELED")
            {
                resetProperty();
                ID_STOP_MARKET = "";
                isStopLoss = false;
            }

            if(ID_TAKE_PROFIT_MARKET == order.c && order.X == "FILLED" || ID_TAKE_PROFIT_MARKET == order.c && order.X == "CANCELED")
            {
                resetProperty();
                ID_TAKE_PROFIT_MARKET = "";
                isTakeProfit = false;
            }
        }

        /// <summary>
        /// Если уровень не совпадает с sp то убираем стоп ордер
        /// </summary>
        private async void checkToHigh()
        {
            if(!isDeal && isStop && (double)high != (double)sp && isRequestCancelOrder)
            {
                isRequestCancelOrder = false;
                ResponseOrder ro = await Task.Run(() => client.cancelStopOrder(ID_STOP_ORDER));
                await Task.Delay(1000);
                if (ro != null && ro.status == "CANCELED")
                {
                    isStop = false;
                    isRequestCancelOrder = true;
                }
            }
        }
        /// <summary>
        /// Проверка дистанции
        /// </summary>
        private async void checkDistance()
        {
            if(!isDeal && isStop && (client.getPercToHigh().CompareTo(client.getPercToCancelOrder()) > 0) && isRequestCancelOrder){
                isRequestCancelOrder = false;
                ResponseOrder ro = await Task.Run(() => client.cancelStopOrder(ID_STOP_ORDER));
                await Task.Delay(1000);
                if(ro != null && ro.status == "CANCELED")
                {
                    isStop = false;
                    isRequestCancelOrder = true;
                }
            }
        }
        /// <summary>
        /// Отменям стоп ордер, если мы в сделке
        /// </summary>
        private async void checkIsDealShort()
        {
            if(!isDeal && isStop && (client.dealShort.isDeal) && isRequestCancelOrder)
            {
                isRequestCancelOrder = false;
                ResponseOrder ro = await Task.Run(() => client.cancelStopOrder(ID_STOP_ORDER));
                await Task.Delay(1000);
                if(ro!=null && ro.status == "CANCELED")
                {
                    isStop = false;
                    isRequestCancelOrder = true;
                }
            }
        }

        public async void rePlaceStopLoss(string ex)
        {
            if (ex.IndexOf("400") != -1 && !isStopLoss && isDeal)
            {
                isRequestNewStopLoss = false;
                await Task.Run(() => client.calculStopLoss("BUY", client.currentPrice));
                ResponseOrder ro = await Task.Run(() => client.newStopLoss("BUY"));
                await Task.Delay(2000);
                if (ro.status == "NEW")
                {
                    ID_STOP_MARKET = ro.clientOrderId;
                    isStopLoss = true;
                    isRequestNewStopLoss = true;
                }
            }
        }

        public async void rePlaceTakeProfit(string ex)
        {
            if(ex.IndexOf("400")!=-1 && !isTakeProfit && isDeal)
            {
                isRequestNewTakeProfit = false;
                await Task.Run(() => client.calculateTakeProfit("BUY", averagePrice));
                ResponseOrder ro = await Task.Run(() => client.newTakeProfit("BUY"));
                await Task.Delay(1000);
                if(ro.status == "NEW")
                {
                    ID_TAKE_PROFIT_MARKET = ro.clientOrderId;
                    isTakeProfit = true;
                    isRequestNewTakeProfit = true;
                }
            }
        }
        public async void cancelStopLoss()
        {
            ResponseOrder ro = await Task.Run(() => client.cancelStopOrder(ID_STOP_MARKET));
            await Task.Delay(2000);
            if (ro != null && ro.status == "CANCELED")
            {
                isStopLoss = false;
            }
        }
        public async void cancelTakeProfit()
        {
            ResponseOrder ro = await Task.Run(() => client.cancelStopOrder(ID_TAKE_PROFIT_MARKET));
            await Task.Delay(2000);
            if (ro != null && ro.status == "CANCELED")
            {
                isTakeProfit = false;
            }
        }
    }
}
