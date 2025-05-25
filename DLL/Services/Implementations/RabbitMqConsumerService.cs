using Microsoft.Extensions.Hosting;
using Models.Dtos;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class RabbitMqConsumerService:BackgroundService
    {
        private readonly ConnectionFactory _factory;
        private IConnection? _connection;
        private IModel? _channel;

        public RabbitMqConsumerService()
        {
            // הגדרת פרטי החיבור ל-RabbitMQ
            _factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // יצירת חיבור וערוץ
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            // יצירת התור (אם הוא לא קיים)
            _channel.QueueDeclare(queue: "product_queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(_channel);

            // טיפול בהודעות נכנסות
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var messageJson = Encoding.UTF8.GetString(body);

                Console.WriteLine($"[RabbitMQ] Received message: {messageJson}");

                // לדוגמה: המרה לאובייקט והפעלת עיבוד
                var productMessage = JsonConvert.DeserializeObject<ProductCreatedMessageDTO>(messageJson);
                if (productMessage != null)
                {
                    ProcessProductMessage(productMessage);
                }
            };

            // התחלת צריכת ההודעות (קונסומציה)
            _channel.BasicConsume(queue: "product_queue",
                                 autoAck: true,
                                 consumer: consumer);

            // השיטה הזו מסיימת מיד (הצריכה ממשיכה ברקע)
            return Task.CompletedTask;
        }

        private void ProcessProductMessage(ProductCreatedMessageDTO product)
        {
            // כאן תוכל להוסיף את הלוגיקה שלך, לדוגמה לעדכן את ההזמנות
            Console.WriteLine($"Processing product: Id={product.Id}, Name={product.Name}");
        }

        public override void Dispose()
        {
            // ניקוי המשאבים בזמן סגירת השירות
            _channel?.Close();
            _connection?.Close();
            base.Dispose();
        }
    }
}
