namespace RabbitMq
{
    public interface IEventBus
    {
         void publish(string msg);
         void subscribe();
    }
}