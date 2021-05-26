using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using TobinTaxService.Controllers;

namespace TobinTaxService.Models
{
    public static class RabbitMQConsumer
    {         
        public static void Consume(IModel channel)
        {
            channel.QueueDeclare("tax-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) => {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                //Adding tax stub
                var tobinTax = new TobinTaxModel();
                tobinTax.BoughtStock = "Ris";
                tobinTax.PayedTax = 100;
                tobinTax.TraderId = Guid.NewGuid();
                tobinTax.TaxId = Guid.NewGuid();

                //Push tax to db
            };

            channel.BasicConsume("tax-queue", true, consumer);            
        }
    }
}
