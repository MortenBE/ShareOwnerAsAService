using ApiProxyService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiProxyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProxyController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        public ApiProxyController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /*
        // GET: api/Shares
        [HttpGet]
        public string GetShare()
        {
            return "Hello World";
        }
        */

        // GET: api/Shares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Share>>> GetShare()
        {           
            var client = _clientFactory.CreateClient("backend");


            var response = await client.GetAsync("Shares");

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var shares = JsonConvert.DeserializeObject<List<Share>>(responseBody);

            return shares;
        }
    }
}


