using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareOwnerControl.Models
{
    public class Transaction
    {
        Guid TraderId { get; set; }
        Guid StockId { get; set; }
    }
}
