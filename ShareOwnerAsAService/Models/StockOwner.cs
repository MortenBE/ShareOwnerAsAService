using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShareOwnerAsAService.Models
{
    public class StockOwner
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public HashSet<Stock> StockPortfolio { get; set; }
    }
}
