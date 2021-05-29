using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using RequesterService.Models;

namespace RequesterService
{
    public class RequesterDomain
    {
        private readonly IHttpClientFactory _clientFactory;
        public RequesterDomain(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async void notifyRequest(RequesterModel model)
        {
            var client = _clientFactory.CreateClient("BrokerService");

            var content = JsonConvert.SerializeObject(model);

            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            await client.PostAsync(client.BaseAddress + "Broker/Request", stringContent);

        }

    }
}
