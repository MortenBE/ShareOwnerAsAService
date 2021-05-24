using System;
using System.ComponentModel.DataAnnotations;

namespace ShareService.Models
{
    public class ShareServiceModel
    {
        [Key]
        public Guid ShareId { get; set; }
        public string Stock { get; set; }
        public Guid TraderId { get; set; }
        public int Value { get; set; }
    }
}
