using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShareOwnerControl.Models
{
    public class TransactionServiceDomain
    {
        private readonly IHttpClientFactory _clientFactory;
        public TransactionServiceDomain(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async void updateOwnership(Transaction transaction)
        {
            var BrokerClient = _clientFactory.CreateClient("BrokerService");

            var response = await BrokerClient.GetAsync("Broker");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var content = JsonConvert.De
        }
    }


}
