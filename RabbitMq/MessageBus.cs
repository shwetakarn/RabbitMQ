using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMq
{
    public class MessageBus : IEventBus
    {
        public void publish(string msg)
        {
           var factory = new ConnectionFactory{
                 HostName = "",
                 UserName = "",
                 Password = "",
                 Port = 5672,   // Default Port of RabbitMq
                 
            };
            // creating the socket and with in the socket creating the channel
            using(var connection = factory.CreateConnection()){
                using(var channel = connection.CreateModel()){
                    // Creating queue with in the channel
                    channel.QueueDeclare("EshopQueue",false,false,false,null);
                    var byteMsg = Encoding.UTF8.GetBytes(msg);
                    channel.BasicPublish("","EshopQueue",body:byteMsg);
                    Console.WriteLine("Message Published "+ msg);
                }
            }
        }

        public void subscribe()
        {
            throw new System.NotImplementedException();
        }

        public void SubscribeProcess()
        {
            var factory = new ConnectionFactory{
                 HostName = "",
                 UserName = "",
                 Password = "",
                 Port = 5672,   // Default Port of RabbitMq
                 
            };
            // creating the socket and with in the socket creating the channel
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            // Creating queue with in the channel
            channel.QueueDeclare("EshopQueue",false,false,false,null);  
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var mes = Encoding.UTF8.GetString(body);
            Console.WriteLine();
        }
    }
}