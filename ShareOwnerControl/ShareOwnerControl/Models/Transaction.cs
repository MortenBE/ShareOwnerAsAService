using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareOwnerControl.Models
{
    public class Transaction
    {
        public Guid TraderId { get; set; }
        public Guid ShareId { get; set; }
    }
}
