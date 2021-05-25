using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using ProviderService.Models;

namespace ProviderService
{
    public class ProviderDomain
    {
        private readonly IHttpClientFactory _clientFactory;
        public ProviderDomain(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async void notifyProvided(ProviderModel model)
        {
            var client = _clientFactory.CreateClient("BrokerService");

            var content = JsonConvert.SerializeObject(model);

            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");


            await client.PostAsync(client.BaseAddress + "Broker/Provide", stringContent);

        }

    }
}

