using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TobinTaxControl.Models
{
    public class Tax
    {
        [Key]
        public int Id { get; set; }
        public int Value { get; set; }
        public int TraderId { get; set; }
        public int ShareId { get; set; }
        public DateTime Date { get; set; }
    }
}
