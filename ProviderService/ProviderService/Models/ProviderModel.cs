using System;
using System.ComponentModel.DataAnnotations;

namespace ProviderService.Models
{
    public class ProviderModel
    {
        [Key]
        public Guid ProviderId { get; set; }
        public string Stock { get; set; }
        public Guid StockId { get; set; }
    }
}
