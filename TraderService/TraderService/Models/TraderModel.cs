using System;
using System.ComponentModel.DataAnnotations;

namespace TraderService.Models
{
    public class TraderModel
    {
            [Key]
            public Guid TraderId { get; set; }
    }
}
