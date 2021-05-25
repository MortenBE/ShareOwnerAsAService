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
    public class BrokerController : Controller
    {
        private BrokerServiceDomain _domain; 
        public BrokerController(IHttpClientFactory httpClientFactory)
        {
            _domain = new BrokerServiceDomain(httpClientFactory);
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [Route("Request")]
        [HttpPost]
        public void RequestPost(string value)
        {
            _domain.BuyShare(JsonConvert.DeserializeObject<Requester>(value));
        }

        // POST api/values
        [Route("Provide")]
        [HttpPost]
        public void ProvidePost(string value)
        {
            _domain.SellShare(JsonConvert.DeserializeObject<Provider>(value));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
