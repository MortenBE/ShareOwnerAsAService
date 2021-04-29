using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTraderBroker.Models
{
    public class StockSell
    {
        public int Id { get; set; }
        public int TraderId { get; set; }
        public int StockValue { get; set; }
        public int StockName { get; set; }


    }
}
