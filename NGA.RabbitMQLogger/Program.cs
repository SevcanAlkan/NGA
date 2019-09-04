using Newtonsoft.Json;
using NGA.Core.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace NGA.RabbitMQLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
            };

            bool continueToRuning = true;

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {                

                channel.QueueDeclare(queue: "NQueue",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                do
                {
                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, mq) =>
                    {
                        var body = mq.Body;
                        var message = Encoding.UTF8.GetString(body);
                        NotificationVM notification = JsonConvert.DeserializeObject<NotificationVM>(message);
                        Console.WriteLine($"[{notification.DateTime}] - Gonderen: {notification.SenderName}, Mesaj: {notification.Message} ");
                    };

                    channel.BasicConsume(queue: "NQueue",
                                     autoAck: true,//true ise mesaj otomatik olarak kuyruktan silinir
                                     consumer: consumer);
                    
                    

                    System.Threading.Thread.Sleep(5000);

                } while (continueToRuning);
                             
                Console.ReadKey();

            }
        }
    }
}
