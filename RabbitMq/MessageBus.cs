using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace RabbitMq
{
    public class MessageBus : IEventBus
    {
        public void publish(string msg)
        {
            throw new System.NotImplementedException();
        }

        public void subscribe()
        {
            throw new System.NotImplementedException();
        }

        public void SubscribeProcess()
        {

        }
    }
}