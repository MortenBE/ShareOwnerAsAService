using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShareOwnerControl.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShareOwnerControl.Controllers
{
    [Route("api/[controller]")]
    public class ShareOwnerController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public ShareOwnerController(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
        }


        [Route("UpdateOwnership")]
        [HttpPut]
        public async Task<ActionResult<HttpResponseMessage>> UpdateOwnership(Transaction txn)
        {
            var share = new Share() { ShareId = txn.ShareId, TraderId = txn.TraderId };
            var client = _clientFactory.CreateClient("ShareService");
            var content = JsonConvert.SerializeObject(share);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(client.BaseAddress + "Share", stringContent);

            return response;
        }
    }    
        

   
    

}
