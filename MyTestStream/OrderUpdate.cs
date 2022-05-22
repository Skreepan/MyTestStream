using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestStream
{
    internal class OrderUpdate
    {
        /// <summary>
        /// Тип события
        /// </summary>
        public string e { get; set; }
        /// <summary>
        /// Время события
        /// </summary>
        public long E { get; set; }
        /// <summary>
        /// Время транзакции
        /// </summary>
        public long T { get; set; }
        /// <summary>
        /// Информация по ордеру
        /// </summary>
        public Order o { get; set; }
    }
}
