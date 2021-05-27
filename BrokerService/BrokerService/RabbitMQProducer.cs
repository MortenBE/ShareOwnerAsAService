using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerService
{
    public static class RabbitMQProducer
    {
        public static void Publish(IModel channel, string json)
        {
            channel.QueueDeclare(queue: "tax-queue",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
            
            //string message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "",
                                     routingKey: "tax-queue",
                                     basicProperties: null,
                                     body: body);
        }
    }
}
