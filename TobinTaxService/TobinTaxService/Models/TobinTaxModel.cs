using System;
using System.ComponentModel.DataAnnotations;

namespace TobinTaxService.Models
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
