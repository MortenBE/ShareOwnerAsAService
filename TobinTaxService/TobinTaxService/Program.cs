using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using TobinTaxService.Models;

namespace TobinTaxService
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var factory = new ConnectionFactory() {
                HostName = "localhost"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            RabbitMQConsumer.Consume(channel);

            CreateHostBuilder(args).Build().Run();

           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
