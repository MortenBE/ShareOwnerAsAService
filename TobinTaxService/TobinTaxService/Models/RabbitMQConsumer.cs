using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            _hostname = "localhost";
            _serviceProvider = serviceProvider;      
            InitRabbitMQConsumer();
        }

        private void InitRabbitMQConsumer()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostname
            };

            _connection = factory.CreateConnection();
            //_connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
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
                AddTobinTax();
            };

            _channel.BasicConsume("tax-queue", true, consumer);

            return Task.CompletedTask;
        }

        public async void AddTobinTax()
        {
            //Adding tax stub
            var tobinTax = new TobinTaxModel();
            tobinTax.BoughtStock = "Ris";
            tobinTax.PayedTax = 100;
            tobinTax.TraderId = Guid.NewGuid();
            tobinTax.TaxId = Guid.NewGuid();

            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<TobinTaxDbContext>();

                context.TobinTaxModel.Add(tobinTax);
                await context.SaveChangesAsync();
            }
        }
    }
}
