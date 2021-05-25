using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareOwnerControl.Models
{
    public class Share
    {
        public Guid ShareId { get; set; }
        public string Stock { get; set; }
        public Guid TraderId { get; set; }
        public int Value { get; set; }
    }
}
