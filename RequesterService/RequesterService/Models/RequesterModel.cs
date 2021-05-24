using System;
using System.ComponentModel.DataAnnotations;

namespace RequesterService.Models
{
    public class RequesterModel
    {
        [Key]
        public Guid RequesterId { get; set; }
        public string Share { get; set; }
    }
}
