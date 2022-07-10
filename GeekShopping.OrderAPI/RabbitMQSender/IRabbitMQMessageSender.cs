using GeekShopping.Integration.DTOs;

namespace GeekShopping.OrderAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessageDTO message, string queueName);
    }
}
