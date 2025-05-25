using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace BLL.Services.Implementations
{
    public class RabbitMessageBusService: IMessageBusService
    {
        private readonly ConnectionFactory _factory;

        public RabbitMessageBusService()
        {
            _factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
        }

        public void SendMessage<T>(T message, string queueName)
        {
            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "",
                                 routingKey: queueName,
                                 basicProperties: null,
                                 body: body);
        }
    }
}
