using System;
namespace ApiProxyService.Models
{
    public class Provide
    {
        public Guid ProviderId { get; set; }
        public Guid TraderId { get; set; }
        public string Stock { get; set; }
        public Guid StockId { get; set; }
        public double StockValue { get; set; }
    }
}
