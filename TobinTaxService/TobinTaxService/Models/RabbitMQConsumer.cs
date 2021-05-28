using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//https://www.programmingwithwolfgang.com/rabbitmq-in-an-asp-net-core-3-1-microservice/
namespace TobinTaxService.Models
{
    public class RabbitMQConsumer : BackgroundService
    {
        private IModel _channel;
        private IConnection _connection;
        IServiceProvider _serviceProvider;

        private readonly string _hostname;
        private readonly string _queueName;
        private readonly string _username;
        private readonly string _password;

        public RabbitMQConsumer(IServiceProvider serviceProvider)
        {
            _hostname = AppSettings.Get<string>("RabbitMQ");
            _serviceProvider = serviceProvider;      
            InitRabbitMQConsumer();
        }

        private void InitRabbitMQConsumer()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostname,
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();      
            _channel = _connection.CreateModel();
            
            _channel.QueueDeclare("tax-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var soldStock = JsonConvert.DeserializeObject<TobinTaxModel>(message);

                AddTobinTax(soldStock);
            };

            _channel.BasicConsume("tax-queue", true, consumer);

            return Task.CompletedTask;
        }

        public async void AddTobinTax(TobinTaxModel soldStock)
        {
            //Adding tax stub
            var tax = new TobinTaxModel();
            tax.TaxId = Guid.NewGuid();
            tax.TraderId = soldStock.TraderId;
            tax.BoughtStock = soldStock.BoughtStock;            
            tax.PayedTax = soldStock.PayedTax * 0.10;            

            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<TobinTaxDbContext>();

                context.TobinTaxModel.Add(tax);
                await context.SaveChangesAsync();
            }
        }
    }
}
