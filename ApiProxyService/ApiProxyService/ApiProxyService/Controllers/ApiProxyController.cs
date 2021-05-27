using ApiProxyService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Share>>> GetShare()
        {           
            var client = _clientFactory.CreateClient("ShareService");


            var response = await client.GetAsync("Share");

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var shares = JsonConvert.DeserializeObject<List<Share>>(responseBody);

            return shares;
        }

        [HttpPost]
        public async Task<ActionResult<HttpResponseMessage>> PostShare(Share share)
        {
            var client = _clientFactory.CreateClient("ShareService");

            var content = JsonConvert.SerializeObject(share);

            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");


            var response = await client.PostAsync(client.BaseAddress + "Share", stringContent);

            return response;
        }
        [Route("Traders")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trader>>> GetTraders()
        {
            var client = _clientFactory.CreateClient("TraderService");


            var response = await client.GetAsync("Trader");

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var traders = JsonConvert.DeserializeObject<List<Trader>>(responseBody);

            return traders;
        }
        [Route("Traders")]
        [HttpPost]
        public async Task<ActionResult<HttpResponseMessage>> PostTrader(Trader trader)
        {
            var client = _clientFactory.CreateClient("TraderService");

            var content = JsonConvert.SerializeObject(trader);

            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");


            var response = await client.PostAsync(client.BaseAddress + "Trader", stringContent);

            return response;
        }
        [Route("Request")]
        [HttpPost]
        public async Task<ActionResult<HttpResponseMessage>> PostRequest(Request request)
        {
            var client = _clientFactory.CreateClient("RequesterService");

            var content = JsonConvert.SerializeObject(request);

            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(client.BaseAddress + "Requester", stringContent);

            return response;
        }
        [Route("Provide")]
        [HttpPost]
        public async Task<ActionResult<HttpResponseMessage>> PostProvide(Share share)
        {
            var providedShare = new Provide()
            {
                ProviderId = Guid.NewGuid(),
                TraderId = share.TraderId,
                Stock = share.Stock,
                StockId = share.ShareId,
                StockValue = share.Value
            };     

            var client = _clientFactory.CreateClient("ProviderService");

            var content = JsonConvert.SerializeObject(providedShare);

            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(client.BaseAddress + "Provider", stringContent);

            return response;
        }
    }
}


