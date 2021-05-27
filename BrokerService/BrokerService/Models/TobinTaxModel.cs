using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrokerService.Models
{
    public class TobinTaxModel
    {
        [Key]
        public Guid TaxId { get; set; }
        public Guid TraderId { get; set; }
        public string BoughtStock { get; set; }
        public double PayedTax { get; set; }
    }
}
