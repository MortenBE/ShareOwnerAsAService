using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProxyService.Models
{
    public class Share
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public int TraderId { get; set; }
    }

}
