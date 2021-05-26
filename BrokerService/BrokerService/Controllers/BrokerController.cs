using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrokerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrokerController : ControllerBase
    {
        private BrokerServiceDomain _domain; 
        public BrokerController(IHttpClientFactory httpClientFactory)
        {
            _domain = new BrokerServiceDomain(httpClientFactory);
        }

        // POST api/values
        [Route("Request")]
        [HttpPost]
        public void RequestPost(Requester value)
        {
            _domain.BuyShare(value);
        }

        // POST api/values
        [Route("Provide")]
        [HttpPost]
        public void ProvidePost(Provider value)
        {

            _domain.SellShare(value);
        }
    }
}
