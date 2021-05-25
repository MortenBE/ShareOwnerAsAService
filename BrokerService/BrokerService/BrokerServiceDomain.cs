using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace BrokerService
{
    public class BrokerServiceDomain
    {
        private readonly IHttpClientFactory _clientFactory;
        public BrokerServiceDomain(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async void buyShare(Requester requester)
        {
            var ProviderClient = _clientFactory.CreateClient("ProviderService");
            var RequesterClient = _clientFactory.CreateClient("RequesterService");
            var ShareControlClient = _clientFactory.CreateClient("ShareControlService");

            var response = await ProviderClient.GetAsync("Provider");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var ProvidedStocks = JsonConvert.DeserializeObject<List<Provider>>(responseBody);

            var providedStock = ProvidedStocks.Find(x => x.Stock == requester.Share);

            if(providedStock != null)
            {
                await ProviderClient.DeleteAsync(providedStock.ProviderId.ToString());
                await RequesterClient.DeleteAsync(requester.RequesterId.ToString());

                var trans = new transactionModel()
                {
                    ShareId = providedStock.StockId,
                    TraderId = requester.RequesterId
                };

                
                var stringContent = new StringContent(JsonConvert.SerializeObject(trans), Encoding.UTF8, "application/json");

                var result = ShareControlClient.PostAsync("ShareOwner", stringContent);

                // RabbitMQ stuff
            }
        }

        public async void sellShare(Provider provider)
        {
            var ProviderClient = _clientFactory.CreateClient("ProviderService");
            var RequesterClient = _clientFactory.CreateClient("RequesterService");
            var ShareControlClient = _clientFactory.CreateClient("ShareControlService");

            var response = await RequesterClient.GetAsync("Requester");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var RequestedShares = JsonConvert.DeserializeObject<List<Requester>>(responseBody);

            var findReqShare = RequestedShares.Find(x => x.Share == provider.Stock);

            if (findReqShare != null)
            {
                await ProviderClient.DeleteAsync(provider.ProviderId.ToString());
                await RequesterClient.DeleteAsync(findReqShare.RequesterId.ToString());

                var trans = new transactionModel()
                {
                    ShareId = provider.StockId,
                    TraderId = findReqShare.RequesterId
                };


                var stringContent = new StringContent(JsonConvert.SerializeObject(trans), Encoding.UTF8, "application/json");

                var result = ShareControlClient.PostAsync("ShareOwner", stringContent);

                // RabbitMQ stuff
            }
        }
    }
}
