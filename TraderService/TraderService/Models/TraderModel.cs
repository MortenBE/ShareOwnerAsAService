using System;
using System.ComponentModel.DataAnnotations;

namespace TraderService.Models
{
    public class TraderModel
    {
        [Key]
        [StringLength(86)]
        public Guid TraderId { get; set; }
    }
}
