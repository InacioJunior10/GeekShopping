using GeekShopping.Integration.DTOs;

namespace GeekShopping.CartAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessageDTO message, string queueName);
    }
}
