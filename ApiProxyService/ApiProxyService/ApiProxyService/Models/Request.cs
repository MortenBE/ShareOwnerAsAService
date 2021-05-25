using System;
namespace ApiProxyService.Models
{
    public class Request
    {
        public Guid RequesterId { get; set; }
        public string Share { get; set; }
    }
}
