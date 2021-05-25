using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProxyService.Models
{
    public class Share
    {
        public Guid ShareId { get; set; }
        public string Stock { get; set; }
        public Guid TraderId { get; set; }
        public int Value { get; set; }
    }

}
