using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestStream
{
    internal class LevelsHL
    {
        private decimal high = 0.0m;
        private decimal low = 99999999999.9m;
        private Candle[] _candles;
        private int maxIndex;
        private int highIndex;
        private int lowIndex;
        private int rangeBars = 300;
        private int startBars = 10;

        public decimal getHigh()
        {
            high = 0.0m;
            for (int i = maxIndex - rangeBars; i < maxIndex - startBars; i++)
            {
                if (_candles[i].high.CompareTo(high) > 0)
                {
                    high = _candles[i].high;
                    highIndex = i;
                }
            }
            return high;
        }

        public decimal getLow()
        {
            low = 99999999999.9m;
            for (int i = maxIndex - rangeBars; i < maxIndex - startBars; i++)
            {
                if (_candles[i].low.CompareTo(low) < 0)
                {
                    low = _candles[i].low;
                    lowIndex = i;
                }
            }
            return low;
        }

        /// <summary>
        /// установить массив со свечами
        /// </summary>
        /// <param name="candle"></param>
        public void setCandles(object[][] arr)
        {
            _candles = new Candle[arr.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                _candles[i] = new Candle(arr[i]);
            }
        }

        /// <summary>
        /// Установить индекс текущей свечи
        /// </summary>
        /// <param name="i"></param>
        public void setMaxIndex(int i)
        {
            maxIndex = i;
        }

        /// <summary>
        /// Проверка на закол хая
        /// </summary>
        /// <returns></returns>
        public bool checkIsStabHigh()
        {
            bool isStabHigh = false;
            for (int i = highIndex; i < maxIndex; i++)
            {
                if (high.CompareTo(_candles[i].high) < 0)
                {
                    isStabHigh = true;
                }
            }
            return isStabHigh;
        }

        /// <summary>
        /// Проверка на закол лоя
        /// </summary>
        /// <returns></returns>
        public bool checkIsStabLow()
        {
            bool isStabLow = false;
            for (int i = lowIndex; i < maxIndex; i++)
            {
                if (low.CompareTo(_candles[i].low) > 0)
                {
                    isStabLow = true;
                }
            }
            return isStabLow;
        }

        public void setRangeBars(int value)
        {
            rangeBars = value;
        }

        public int getRangeBars()
        {
            return rangeBars;
        }

        public void setStartBars(int value)
        {
            startBars = value;
        }

        public int getStartBars()
        {
            return startBars;
        }

        public decimal getCurrentPrice()
        {
            return _candles[999].close;
        }
    }
}
