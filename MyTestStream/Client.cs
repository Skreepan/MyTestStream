using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.ComponentModel;

namespace MyTestStream
{
    internal class Client
    {
        private static string nameForPath = "";
        private int afterDot;
        private decimal step;
        private double priceDouble;
        //private string path = @"C:\Users\JD\Desktop\Test\"+$"{nameForPath}" +"LOG.txt";
        private StreamWriter sw;

        private Candlestick candlestick = new Candlestick();
        private WebSocket wsKline;
        public List<string> list_stopLossErrors;
        public List<string> list_TakeProfitErrors;
        public List<string> list_newStopOrderBuy;
        public List<string> list_newStopOrderSell;
        public List<string> list_cancelStopOrder;
        public int countTP = 0;
        public int countSL = 0;
        public int countStopOrderBuy = 0;
        public int countStopOrderSell = 0;
        public int countCancelOrder = 0;
        /*Test*/
        public DealLong dealLong;
        public DealShort dealShort;

        private bool firstInit = false;
        public decimal high;
        public decimal low;
        private decimal percToHigh;
        private decimal percToLow;
        public decimal currentPrice;
        public Form1 form1;
        private StreamUpdateOrder streamUpdateOrder;
        private WebRequest wsUpdateOrder;

        public bool orderLong = false;
        public bool orderShort = false;

        private RequestBinance rb;
        private string name = "GALA";
        private string lowName;
        private WebSocket ws;
        private string info;
        private OrderUpdate orderUpdate = new OrderUpdate();
        private LevelsHL levelsHL = new LevelsHL();

        private string apiKEY = "";
        private string secretKey = "";
        private WebRequest webRequestBuy;
        private WebRequest webRequestSell;
        private WebRequest webRequestSL;
        private WebRequest webRequestTP;
        private WebRequest webRequestCancel;
        private WebRequest webRequestListenKey;

        private readonly string USDT_M_FUTURES = "https://fapi.binance.com";
        private readonly string NEW_ORDER = "/fapi/v1/order?";
        private readonly string LISTEN_KEY = "/fapi/v1/listenKey";
        private string requestBody = "";
        private const string X_MBX_APIKEY = "X-MBX-APIKEY";
        private string lastIdOrig = "";
        /*PARAMS*/
        private string symbol = "DENTUSDT";
        private string side = "BUY";
        private string type = "STOP"; //Order Types
        private double quantity = 100;
        private string myTimestamp = "";
        private string price = "0.003600";
        private string mask;
        private int leverage = 1;
        private int amount = 0;

        private decimal percToCancelOrder = 1.0m;
        private decimal percToSetOrder = 0.5m;

        public decimal mySL = 0.00m;
        public decimal myTP = 0.00m;
        //Для рассчета
        public decimal inputSL = 0.005m;
        public decimal inputTP = 0.02m;

        public Client(Form1 f)
        {
            lowName = name.ToLower();
            nameForPath = name;
            list_stopLossErrors = new List<string>();
            list_TakeProfitErrors = new List<string>();
            list_newStopOrderBuy = new List<string>();
            list_newStopOrderSell = new List<string>();
            list_cancelStopOrder = new List<string>();
            dealLong = new DealLong(this);
            dealLong.setCoinName(name);
            dealShort = new DealShort(this);
            dealShort.setCoinName(name);
            rb = new RequestBinance(this);
            form1 = f;
            rb.getKlines();
        }

        public void loop()
        {
            //loopOfTrade();
            if (firstInit)
            {
                dealShort.loopTrade();
                dealLong.loopTrade();

                form1.labelStep.Text = step.ToString();
                form1.labelPriceDouble.Text = priceDouble.ToString();
            }
        }

        /// <summary>
        /// Открыть стоп ордер
        /// </summary>
        public ResponseOrder newStopOrderBuy()
        {
            //string sp = high.ToString(mask).Replace(",", ".");
            string sp = Math.Round(high, afterDot).ToString().Replace(",", ".");
            decimal val = high + step;
            //string myPrice = val.ToString(mask).Replace(",",".");
            string myPrice = Math.Round(val, afterDot).ToString().Replace(",", ".");
            ResponseOrder answer = new ResponseOrder();
            if(!orderLong || orderLong)
            {
                orderLong = true;
                myTimestamp = Math.Round(DateTimeToUnixTimestamp(DateTime.Now)).ToString();
                requestBody = $"symbol={name}USDT&side=BUY&type=STOP&timeInForce=GTC&quantity={quantity}&price={myPrice}&stopPrice={sp}&recvWindow=5000&timestamp=" + $"{myTimestamp}";

                byte[] dataQ = Encoding.UTF8.GetBytes(requestBody);
                byte[] bytesApiSecret = Encoding.ASCII.GetBytes(secretKey);
                byte[] bytesSignature = new HMACSHA256(bytesApiSecret).ComputeHash(dataQ);
                string signature = BitConverter.ToString(bytesSignature).Replace("-", "").ToLower();
                string fullUri = $"{USDT_M_FUTURES}" + $"{NEW_ORDER}" + $"{requestBody}" + "&signature=" + $"{signature}";
                Uri uri = new Uri($"{USDT_M_FUTURES}" + $"{NEW_ORDER}" + $"{requestBody}" + "&signature=" + $"{signature}");

                try
                {
                    countStopOrderBuy++;
                    webRequestBuy = WebRequest.Create(uri);
                    webRequestBuy.Method = "POST";
                    webRequestBuy.Headers.Add(X_MBX_APIKEY, apiKEY);
                    WebResponse response = webRequestBuy.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string res = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    writeToLog(countStopOrderBuy,countStopOrderSell,countSL,countTP,countCancelOrder, "New Stop Order BUY",fullUri,res);
                    answer = JsonConvert.DeserializeObject<ResponseOrder>(res);
                    list_newStopOrderBuy.Add(res);
                }
                catch (WebException ex)
                {
                    writeToLog(countStopOrderBuy, countStopOrderSell, countSL, countTP, countCancelOrder, "New Stop Order BUY", fullUri, "-", ex.Message);
                    string kek = ex.Message ;
                    list_newStopOrderBuy.Add("Order Buy error "+ ex.Message);
                }
                
            }
            return answer;
            
        }
        /// <summary>
        /// Открытие стоп ордера на продажу
        /// </summary>
        /// <returns></returns>
        public ResponseOrder newStopOrderSell()
        {
            //string sp = low.ToString(mask).Replace(",", ".");
            string sp = Math.Round(low, afterDot).ToString().Replace(",", ".");
            decimal val = low - step;
            //string myPrice = val.ToString(mask).Replace(",",".");
            string myPrice = Math.Round(val,afterDot).ToString().Replace(",", ".");
            ResponseOrder answer = new ResponseOrder();
            if (!orderShort || orderShort)
            {
                orderShort = true;
                myTimestamp = Math.Round(DateTimeToUnixTimestamp(DateTime.Now)).ToString();
                requestBody = $"symbol={name}USDT&side=SELL&type=STOP&timeInForce=GTC&quantity={quantity}&price={myPrice}&stopPrice={sp}&recvWindow=5000&timestamp=" + $"{myTimestamp}";

                byte[] dataQ = Encoding.UTF8.GetBytes(requestBody);
                byte[] bytesApiSecret = Encoding.ASCII.GetBytes(secretKey);
                byte[] bytesSignature = new HMACSHA256(bytesApiSecret).ComputeHash(dataQ);
                string signature = BitConverter.ToString(bytesSignature).Replace("-", "").ToLower();
                string fullUri = $"{USDT_M_FUTURES}" + $"{NEW_ORDER}" + $"{requestBody}" + "&signature=" + $"{signature}";
                Uri uri = new Uri($"{USDT_M_FUTURES}" + $"{NEW_ORDER}" + $"{requestBody}" + "&signature=" + $"{signature}");
                try
                {
                    countStopOrderSell++;
                    webRequestSell = WebRequest.Create(uri);
                    webRequestSell.Method = "POST";
                    webRequestSell.Headers.Add(X_MBX_APIKEY, apiKEY);
                    WebResponse response = webRequestSell.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string res = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    writeToLog(countStopOrderBuy, countStopOrderSell, countSL, countTP, countCancelOrder, "New Stop Order SELL", fullUri, res);
                    answer = JsonConvert.DeserializeObject<ResponseOrder>(res);
                    list_newStopOrderSell.Add(res);
                }catch(WebException ex)
                {
                    writeToLog(countStopOrderBuy, countStopOrderSell, countSL, countTP, countCancelOrder, "New Stop Order SELL", fullUri, "-", ex.Message);
                    list_newStopOrderSell.Add("Order sell " + ex.Message);
                }
            }
            return answer;
        }

        /// <summary>
        /// Стоп лосс
        /// </summary>
        /// <param name="s"></param>
        public ResponseOrder newStopLoss(string s)
        {
            string mySide = "";
            ResponseOrder answer = new ResponseOrder();
            if (s == "BUY")
            {
                mySide = "SELL";
            }

            if(s == "SELL")
            {
                mySide = "BUY";
            }
            //string myStolLoss = mySL.ToString(mask).Replace(",",".");
            string myStolLoss = Math.Round(mySL,afterDot).ToString().Replace(",", ".");
            myTimestamp = Math.Round(DateTimeToUnixTimestamp(DateTime.Now)).ToString();
            requestBody = $"symbol={name}USDT&side={mySide}&type=STOP_MARKET&timeInForce=GTC&stopPrice={myStolLoss}&closePosition=true&&workingType=MARK_PRICE&recvWindow=5000&timestamp=" + $"{myTimestamp}";

            byte[] dataQ = Encoding.UTF8.GetBytes(requestBody);
            byte[] bytesApiSecret = Encoding.ASCII.GetBytes(secretKey);
            byte[] bytesSignature = new HMACSHA256(bytesApiSecret).ComputeHash(dataQ);
            string signature = BitConverter.ToString(bytesSignature).Replace("-", "").ToLower();
            string fullUri = $"{USDT_M_FUTURES}" + $"{NEW_ORDER}" + $"{requestBody}" + "&signature=" + $"{signature}";
            Uri uri = new Uri($"{USDT_M_FUTURES}" + $"{NEW_ORDER}" + $"{requestBody}" + "&signature=" + $"{signature}");

            try
            {
                countSL++;
                webRequestSL = WebRequest.Create(uri);
                webRequestSL.Method = "POST";
                webRequestSL.Headers.Add(X_MBX_APIKEY, apiKEY);
                WebResponse response = webRequestSL.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string res = reader.ReadToEnd();
                reader.Close();
                response.Close();
                writeToLog(countStopOrderBuy, countStopOrderSell, countSL, countTP, countCancelOrder, $"New StopLOSS Order {mySide}", fullUri, res);
                answer = JsonConvert.DeserializeObject<ResponseOrder>(res);
                list_stopLossErrors.Add(res);
            }
            catch (WebException ex)
            {
                writeToLog(countStopOrderBuy, countStopOrderSell, countSL, countTP, countCancelOrder, $"New StopLOSS Order {mySide}", fullUri, "-", ex.Message);
                list_stopLossErrors.Add("StopLoss - " + ex.Message);
                if(s == "SELL")
                {
                    dealShort.rePlaceStopLoss(ex.Message);
                }

                if (s == "BUY")
                {
                    dealLong.rePlaceStopLoss(ex.Message);
                }
                
                if (ex.Message.IndexOf("429") != -1)
                {
                    form1.Close();
                }
            }
            return answer;
            
        }
        /// <summary>
        /// Тейк профит
        /// </summary>
        /// <param name="s"></param>
        public ResponseOrder newTakeProfit(string s)
        {
            string mySide = "";
            ResponseOrder answer = new ResponseOrder();
            if (s == "BUY")
            {
                mySide = "SELL";
            }

            if (s == "SELL")
            {
                mySide = "BUY";
            }
            //string myTakeProfit = myTP.ToString(mask).Replace(",", ".");
            string myTakeProfit = Math.Round(myTP,afterDot).ToString().Replace(",", ".");
            myTimestamp = Math.Round(DateTimeToUnixTimestamp(DateTime.Now)).ToString();
            requestBody = $"symbol={name}USDT&side={mySide}&type=TAKE_PROFIT_MARKET&timeInForce=GTC&stopPrice={myTakeProfit}&closePosition=true&&workingType=MARK_PRICE&recvWindow=5000&timestamp=" + $"{myTimestamp}";

            byte[] dataQ = Encoding.UTF8.GetBytes(requestBody);
            byte[] bytesApiSecret = Encoding.ASCII.GetBytes(secretKey);
            byte[] bytesSignature = new HMACSHA256(bytesApiSecret).ComputeHash(dataQ);
            string signature = BitConverter.ToString(bytesSignature).Replace("-", "").ToLower();
            string fullUri = $"{USDT_M_FUTURES}" + $"{NEW_ORDER}" + $"{requestBody}" + "&signature=" + $"{signature}";
            Uri uri = new Uri($"{USDT_M_FUTURES}" + $"{NEW_ORDER}" + $"{requestBody}" + "&signature=" + $"{signature}");
            try
            {
                countTP++;
                webRequestTP = WebRequest.Create(uri);
                webRequestTP.Method = "POST";
                webRequestTP.Headers.Add(X_MBX_APIKEY, apiKEY);
                WebResponse response = webRequestTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string res = reader.ReadToEnd();
                reader.Close();
                response.Close();
                writeToLog(countStopOrderBuy, countStopOrderSell, countSL, countTP, countCancelOrder, $"New TakePROFIT Order {mySide}", fullUri, res);
                answer = JsonConvert.DeserializeObject<ResponseOrder>(res);
                list_TakeProfitErrors.Add(res);
            }catch(WebException ex)
            {
                writeToLog(countStopOrderBuy, countStopOrderSell, countSL, countTP, countCancelOrder, $"New TakePROFIT Order {mySide}", fullUri,"-", ex.Message);
                list_TakeProfitErrors.Add("Take Profit - " + ex.Message);
                if (ex.Message.IndexOf("429") != -1)
                {
                    form1.Close();
                }
            }
            return answer;
            
        }
        /// <summary>
        /// Отменить стоп ордер
        /// </summary>
        public ResponseOrder cancelStopOrder(string id)
        {
            ResponseOrder answer = new ResponseOrder();
            myTimestamp = Math.Round(DateTimeToUnixTimestamp(DateTime.Now)).ToString();
            requestBody = $"symbol={name}USDT&origClientOrderId={id}&recvWindow=5000&timestamp=" + $"{myTimestamp}";

            byte[] dataQ = Encoding.UTF8.GetBytes(requestBody);
            byte[] bytesApiSecret = Encoding.ASCII.GetBytes(secretKey);
            byte[] bytesSignature = new HMACSHA256(bytesApiSecret).ComputeHash(dataQ);
            string signature = BitConverter.ToString(bytesSignature).Replace("-", "").ToLower();
            string fullUri = $"{USDT_M_FUTURES}" + $"{NEW_ORDER}" + $"{requestBody}" + "&signature=" + $"{signature}";
            Uri uri = new Uri($"{USDT_M_FUTURES}" + $"{NEW_ORDER}" + $"{requestBody}" + "&signature=" + $"{signature}");

            webRequestCancel = WebRequest.Create(uri);
            webRequestCancel.Method = "DELETE";
            webRequestCancel.Headers.Add(X_MBX_APIKEY, apiKEY);
            try
            {
                countCancelOrder++;
                WebResponse response = webRequestCancel.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string res = reader.ReadToEnd();
                reader.Close();
                response.Close();
                writeToLog(countStopOrderBuy, countStopOrderSell, countSL, countTP, countCancelOrder, "Cancel Order", fullUri, res);
                list_cancelStopOrder.Add(res);
                answer = JsonConvert.DeserializeObject<ResponseOrder>(res);
            }
            catch(WebException ex)
            {
                writeToLog(countStopOrderBuy, countStopOrderSell, countSL, countTP, countCancelOrder, "Cancel Order", fullUri, "-", ex.Message);
                string kek = ex.Message +" Cancel Order" + '\n';
            }
            return answer;
        }

        /// <summary>
        /// Получение ответа от стрима по сделкам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            
            if (e.Data.IndexOf("ORDER_TRADE_UPDATE")!=-1 && e.Data.IndexOf(name)!=-1)
            {
                info += e.Data + '\n';
                orderUpdate = JsonConvert.DeserializeObject<OrderUpdate>(e.Data);
                dealLong.setOrderInfo(orderUpdate.o);
                dealShort.setOrderInfo(orderUpdate.o);
                /*if(orderUpdate.o.X == "NEW" && orderUpdate.o.x == "NEW" && orderUpdate.o.o == "STOP")
                {
                    lastIdOrig = orderUpdate.o.c;
                }
                
                if (orderUpdate.o.X == "FILLED" && orderUpdate.o.x == "TRADE" && orderUpdate.o.o == "LIMIT")
                {
                    calculStopLoss(orderUpdate.o.S);
                    calculateTakeProfit(orderUpdate.o.S);
                    newStopLoss(orderUpdate.o.S);
                    newTakeProfit(orderUpdate.o.S);
                }*/
            }  
        }
        //ToDo: Не особо важжная хуйня
        public string getInfo()
        {
            return info;
        }
        /// <summary>
        /// Получить данные по ордеру
        /// </summary>
        /// <returns></returns>
        public OrderUpdate getInfoOrder()
        {
            return orderUpdate;
        }
        /// <summary>
        /// Перевод текущего времени в юникс время
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (TimeZoneInfo.ConvertTimeToUtc(dateTime) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        /// <summary>
        /// Расчет стоп лося
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public decimal calculStopLoss(string s, decimal price, decimal guardPerc = 0.0m)
        {
            mySL = 0.0m;
            decimal stopLoss= 0.0m;
            decimal order = 0.0m;
            if (s == "SELL")
            {
                if (orderUpdate.o != null)
                {
                    //order = orderUpdate.o.ap;
                    order = price;
                }
                stopLoss = order + (order * (inputSL + guardPerc));
                mySL = stopLoss;
            }

            if(s == "BUY")
            {
                if (orderUpdate.o != null)
                {
                    //order = orderUpdate.o.ap;
                    order = price;
                }
                stopLoss = order - (order * (inputSL + guardPerc));
                mySL = stopLoss;
            }
            return stopLoss;
        }
        /// <summary>
        /// Расчет тейк профита
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public decimal calculateTakeProfit(string s, decimal price, decimal guardPerc = 0.0m)
        {
            myTP = 0.0m;
            decimal order = 0.0m;
            if(s == "SELL")
            {
                if (orderUpdate.o != null)
                {
                    //order = orderUpdate.o.ap;
                    order = price;
                }
                myTP = order - (order * (inputTP+guardPerc));
            }

            if(s == "BUY")
            {
                if (orderUpdate.o != null)
                {
                    //order = orderUpdate.o.ap;
                    order = price;
                }
                myTP = order + (order * (inputTP+guardPerc));
            }
            return myTP;
        }
        /// <summary>
        /// Получить индикатор
        /// </summary>
        /// <returns></returns>
        public LevelsHL getLevelsHL()
        {
            return levelsHL;
        }
        /// <summary>
        /// Получить имя монеты
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            return name;
        }
        /// <summary>
        /// Инициализация свойств от индюка
        /// </summary>
        public void initLowAndHigh()
        {
            levelsHL.setMaxIndex(1000);
            high = levelsHL.getHigh();
            low = levelsHL.getLow();
            currentPrice = levelsHL.getCurrentPrice();
            createMask();
            updatePercToHigh();
            updatePercToLow();
        }
        /// <summary>
        /// Update Klines
        /// </summary>
        public void getKlines()
        {
            rb.getKlines();
        }

        /// <summary>
        /// Запрос ключа
        /// </summary>
        public void requestListenKey()
        {
            Uri uri = new Uri("https://fapi.binance.com/fapi/v1/listenKey");
            webRequestListenKey = WebRequest.Create(uri);
            webRequestListenKey.Method = "POST";
            webRequestListenKey.Headers.Add(X_MBX_APIKEY, apiKEY);
            WebResponse response = webRequestListenKey.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string res = reader.ReadToEnd();
            reader.Close();
            response.Close();
            streamUpdateOrder = JsonConvert.DeserializeObject<StreamUpdateOrder>(res);
        }

        /// <summary>
        /// Стрим активатион
        /// </summary>
        public void startStreamUpdateOrder()
        {
            string s = "wss://fstream.binance.com/ws/" + streamUpdateOrder.listenKey;
            ws = new WebSocket(s);
            ws.OnMessage += Ws_OnMessage;
            ws.ConnectAsync();
            firstInit = true;
        }
        /// <summary>
        /// Обновление данных расстояния в процентах до хая
        /// </summary>
        public void updatePercToHigh()
        {
            percToHigh = Math.Abs(currentPrice / high * 100.0m - 100.0m);
        }
        /// <summary>
        /// Обновление данных расстояния в процентах до лоя
        /// </summary>
        public void updatePercToLow()
        {
            percToLow = Math.Abs(low / currentPrice * 100.0m - 100.0m);
        }
        /// <summary>
        /// Получить исторические данные свечей
        /// </summary>
        public void updateKlines()
        {
            rb.getKlines();
        }

        //ToDo: Старая логика работы трейдов
        /// <summary>
        /// Цикл и логика работы сделок
        /// </summary>
        private void loopOfTrade()
        {
            if (firstInit)
            {
                if (!dealLong.isDeal)
                {
                    //Если расстояние до уровня меньше, чем percToSetOrder, то ставим стоп ордер
                    if (percToHigh.CompareTo(percToSetOrder) < 0 && !dealLong.isStop && !dealLong.isDeal && !levelsHL.checkIsStabHigh())
                    {
                        newStopOrderBuy();
                    }

                    //Отменяет ордер, если хай обновлен
                    if (dealLong.isStop && (double)dealLong.sp != (double)high)
                    {
                        cancelStopOrder(dealLong.ID_STOP_ORDER);
                    }
                }
                if (!dealShort.isDeal)
                {
                    //Если расстояние до уровня меньше, чем percToSetOrder, то ставим стоп ордер
                    if (percToLow.CompareTo(percToSetOrder) < 0 && !dealShort.isStop && !dealShort.isDeal && !levelsHL.checkIsStabLow())
                    {
                        newStopOrderSell();
                    }

                    //Отменяет Ордер, если лоу обновлен
                    if (dealShort.isStop && (double)dealShort.sp != (double)low)
                    {
                        cancelStopOrder(dealShort.ID_STOP_ORDER);
                    }
                }

                //Если расстояние до уровня больше чем percToCancelOrder, то убираем ордер
                if (dealShort.isStop && currentPrice.CompareTo(dealShort.sp) > 0 && percToLow.CompareTo(percToCancelOrder) > 0)
                {
                    cancelStopOrder(dealShort.ID_STOP_ORDER);
                }
                //Если расстояние до уровня больше чем percToCancelOrder, то убираем ордер
                if (dealLong.isStop && currentPrice.CompareTo(dealLong.sp) < 0 && percToHigh.CompareTo(percToCancelOrder) > 0)
                {
                    cancelStopOrder(dealLong.ID_STOP_ORDER);
                }
                
            }

            
        }
        //ToDo: Старая версия генерации маски, которая отбрасывала последние ноли.
        public void createMask()
        {
            string[] lol;
            string example;
            lol = currentPrice.ToString().Split(',');
            int kol = lol[lol.Length - 1].Length;
            afterDot = kol;
            example = "0.";
            for(int i = 0; i < kol; i++)
            {
                example += "#";
            }
            mask = example;
            form1.labelAfterDor.Text = afterDot.ToString();
        }
        /// <summary>
        /// Запуск стрима по текущей свечи
        /// </summary>
        public void startStreamKline()
        {
            string s = $"wss://fstream.binance.com/ws/{lowName}usdt@kline_5m";
            wsKline = new WebSocket(s);
            wsKline.OnMessage += WsKline_OnMessage;
            wsKline.ConnectAsync();
        }

        private void WsKline_OnMessage(object sender, MessageEventArgs e)
        {
            candlestick = JsonConvert.DeserializeObject<Candlestick>(e.Data);
            if(candlestick.k != null)
            {
                currentPrice = candlestick.k.c;
                priceDouble = (double)candlestick.k.c;
            }
        }

        /// <summary>
        /// Установить ApiKey
        /// </summary>
        /// <param name="value"></param>
        public void setApiKey(string value)
        {
            apiKEY = value;
        }
        /// <summary>
        /// Установить SecretKey
        /// </summary>
        /// <param name="value"></param>
        public void setSecretKey(string value)
        {
            secretKey = value;
        }
        /// <summary>
        /// Установить кол-во монет
        /// </summary>
        /// <param name="q"></param>
        public void setQuantity(double q)
        {
            quantity = q * leverage;
        }
        /// <summary>
        /// Получить объем в монетах
        /// </summary>
        /// <returns></returns>
        public double getQuantity()
        {
            return quantity;
        }
        /// <summary>
        /// Установить плечо
        /// </summary>
        /// <param name="value"></param>
        public void setLeverage(int value)
        {
            leverage = value;
        }
        /// <summary>
        /// Получить плечо
        /// </summary>
        /// <returns></returns>
        public int getLeverage()
        {
            return leverage;
        }
        /// <summary>
        /// Установить имя коина
        /// </summary>
        /// <param name="value"></param>
        public void setCoinName(string value)
        {
            name = value.ToUpper();
            lowName = name.ToLower();
            nameForPath = value.ToUpper();
            dealLong.setCoinName(name);
            dealShort.setCoinName(name);
        }
        /// <summary>
        /// Получить имя Монеты
        /// </summary>
        /// <returns></returns>
        public string getNameCoin()
        {
            return name;
        }
        /// <summary>
        /// Установить RangeBars
        /// </summary>
        /// <param name="value"></param>
        public void setRangeBars(int value)
        {
            levelsHL.setRangeBars(value);
        }
        /// <summary>
        /// Получить RangeBars
        /// </summary>
        /// <returns></returns>
        public int getRangeBars()
        {
            return levelsHL.getRangeBars();
        }
        /// <summary>
        /// Установить StartBars
        /// </summary>
        /// <param name="value"></param>
        public void setStartBars(int value)
        {
            levelsHL.setStartBars(value);
        }
        /// <summary>
        /// Получить StartBars
        /// </summary>
        /// <returns></returns>
        public int getStartBars()
        {
            return levelsHL.getStartBars();
        }
        /// <summary>
        /// Установить тейк профит
        /// </summary>
        /// <param name="value"></param>
        public void setTP(decimal value)
        {
            inputTP = value;
        }
        /// <summary>
        /// Получить тейк профит
        /// </summary>
        /// <returns></returns>
        public decimal getTP()
        {
            return inputTP;
        }
        /// <summary>
        /// Установить стоп лосс
        /// </summary>
        /// <param name="value"></param>
        public void setSL(decimal value)
        {
            inputSL = value;
        }
        /// <summary>
        /// Получить СтопЛосс
        /// </summary>
        /// <returns></returns>
        public decimal getSL()
        {
            return inputSL;
        }
        /// <summary>
        /// Установить расстояние активации ордера в процентах
        /// </summary>
        /// <param name="value"></param>
        public void setPercToSetOrder(decimal value)
        {
            percToSetOrder = value;
        }
        public decimal getPercToSetOrder()
        {
            return percToSetOrder;
        }
        /// <summary>
        /// Установить расстояние отмены ордера в процентах
        /// </summary>
        /// <param name="value"></param>
        public void setPercToCancelOrder(decimal value)
        {
            percToCancelOrder = value;
        }
        public decimal getPercToCancelOrder()
        {
            return percToCancelOrder;
        }

        public decimal getPercToHigh()
        {
            return percToHigh;
        }

        public decimal getPercToLow()
        {
            return percToLow;
        }

        public string getApiKey()
        {
            return apiKEY;
        }

        public string getSecretKey()
        {
            return secretKey;
        }

        public DataKline getDataKline()
        {
            return candlestick.k;
        }

        public void setStep(decimal value)
        {
            step = value;
        }

        public decimal getStep()
        {
            return step;
        }

        /// <summary>
        /// Записываем логи в тхт
        /// </summary>
        /// <param name="cBuy"></param>
        /// <param name="cSell"></param>
        /// <param name="sl"></param>
        /// <param name="tp"></param>
        /// <param name="cncl"></param>
        /// <param name="nameFunc"></param>
        /// <param name="req"></param>
        /// <param name="res"></param>
        /// <param name="error"></param>
        private void writeToLog(int cBuy, int cSell, int sl, int tp, int cncl, string nameFunc = "- ", string req = "- ", string res = "-", string error = "-")
        {
            /*string path = @"C:\Users\JD\Desktop\Test\" + $"{nameForPath}" + "-LOG.txt";
            if (!(File.Exists(path)))
            {
                sw = new StreamWriter(path, false, Encoding.Default);
                sw.WriteLine("----------------------Первый Запуск------------------------------");
                sw.Close();
            }
            sw = new StreamWriter(path, true, Encoding.Default);
            sw.WriteLine("----------------------------------------------------");
            sw.WriteLine(DateTime.Now.ToLocalTime().ToString() + ":" + "\n");
            sw.WriteLine("Func Name: " + nameFunc + "\n");
            sw.WriteLine("Count Buy: " + cBuy.ToString());
            sw.WriteLine("Count Sell: " + cSell.ToString());
            sw.WriteLine("Count sl: " + sl.ToString());
            sw.WriteLine("Count tp: " + tp.ToString());
            sw.WriteLine("Count Cancel: " + cncl);
            sw.WriteLine("Request: " + req + "\n");
            sw.WriteLine("Response: " + res + "\n");
            sw.WriteLine("Current Price: " + currentPrice.ToString() + "\n");
            sw.WriteLine("Error: " + error + "\n\n");
            sw.Close();*/
        }
        /// <summary>
        /// Получить книгу ордеров
        /// </summary>
        public void checkStep()
        {
            rb.getOrderBook(name);
        }
        /// <summary>
        /// Получить шаг цены
        /// </summary>
        /// <param name="orderBook"></param>
        public void calculateStep(OrderBook orderBook)
        {
            decimal step = orderBook.asks[4][0] - orderBook.asks[3][0];
            form1.labelStep.Text = step.ToString();
            calculateAfterDot(step);
            form1.labelStep.Text += " " + afterDot.ToString();
        }
        /// <summary>
        /// Считаем кол-во знаков после запятой
        /// </summary>
        /// <param name="value"></param>
        public void calculateAfterDot(decimal value)
        {
            string step = value.ToString();
            string[] parts = step.Split(',');
            step = parts[1];
            for(int i = 0; i < step.Length; i++)
            {
                if(step[i] == '1')
                {
                    afterDot = i+1;
                    continue;
                }
            }
        }
    }
}
