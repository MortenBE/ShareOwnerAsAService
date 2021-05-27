using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace BrokerService
{
    public class BrokerServiceDomain
    {
        private readonly IHttpClientFactory _clientFactory;
        public BrokerServiceDomain(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public void BuyShare(Requester requester) //async
        {
            //RabbitMQ
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            RabbitMQProducer.Publish(channel);

            /*

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

                var delResult1 = await ProviderClient.DeleteAsync(ProviderClient.BaseAddress + "Provider/" + providedStock.ProviderId.ToString());
                var delResult2 = await RequesterClient.DeleteAsync(RequesterClient.BaseAddress + "Requester/" + requester.RequesterId.ToString());        

                if (delResult1.IsSuccessStatusCode && delResult2.IsSuccessStatusCode)
                {
                    var trans = new transactionModel()
                    {
                        ShareId = providedStock.StockId,
                        TraderId = requester.RequesterId
                    };

                    var stringContent = new StringContent(JsonConvert.SerializeObject(trans), Encoding.UTF8, "application/json");

                    var result = ShareControlClient.PostAsync("ShareOwnerControlService", stringContent);
                }   

            }
            */
            
        }

        public async void SellShare(Provider provider)
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
                var delResult1 = await ProviderClient.DeleteAsync(provider.ProviderId.ToString());
                var delResult2 = await RequesterClient.DeleteAsync(findReqShare.RequesterId.ToString());

                if (delResult1.IsSuccessStatusCode && delResult2.IsSuccessStatusCode)
                {
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
}
