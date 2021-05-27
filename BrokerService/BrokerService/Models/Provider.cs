using System;

namespace BrokerService
{
    public class Provider
    {
        public Guid ProviderId { get; set; }
        public Guid TraderId { get; set; }
        public string Stock { get; set; }
        public Guid StockId { get; set; }
        public double StockValue { get; set; }
    }
}