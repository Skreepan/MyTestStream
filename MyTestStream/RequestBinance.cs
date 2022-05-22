using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace MyTestStream
{
    internal class RequestBinance
    {
        private Client client;
        public RequestBinance(Client client)
        {
            this.client = client;
        }
        /// <summary>
        /// Получить истрические данные по свечам
        /// </summary>
        public void getKlines()
        {
            var url = "https://fapi.binance.com/fapi/v1/klines?symbol=" + client.getName() + "USDT&interval=5m&limit=1000";
            Uri uri = new Uri(url);
            WebClient wc = new WebClient();
            string answer;

            wc.DownloadStringCompleted += (sender, e) =>
            {
                answer = e.Result;
                var arr = JsonConvert.DeserializeObject<object[][]>(answer);
                client.getLevelsHL().setCandles(arr);
                client.initLowAndHigh();
            };
            wc.DownloadStringAsync(uri);
        }
        /// <summary>
        /// Получить книгу ордеров
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public OrderBook getOrderBook(string name)
        {
            OrderBook orderBook = new OrderBook();
            string coin = name.ToUpper();
            string url = "https://fapi.binance.com/fapi/v1/depth?symbol=" + coin + "USDT&limit=5";
            Uri uri = new Uri(url);
            WebClient wc = new WebClient();
            string answer;

            wc.DownloadStringCompleted += (sender, e) =>
             {
                 answer = e.Result;
                 orderBook = JsonConvert.DeserializeObject<OrderBook>(answer);
                 client.calculateStep(orderBook);
             };
            wc.DownloadStringAsync(uri);
            return orderBook;
        }
    }
}
