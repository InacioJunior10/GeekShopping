using GeekShopping.OrderAPI.Messages;
using GeekShopping.OrderAPI.Model;
using GeekShopping.OrderAPI.Repository;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GeekShopping.OrderAPI.MessageConsumer
{
    public class RabbitMQCheckoutConsumer : BackgroundService
    {
        private readonly OrderRepository _repository;
        private IConnection _connection;
        private IModel _channel;
        private const string queue = "checkout";

        public RabbitMQCheckoutConsumer(OrderRepository repository)
        {
            _repository = repository;
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
                        
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue, false, false, false);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested ();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (channel, evento) => 
            {
                var content = Encoding.UTF8.GetString(evento.Body.ToArray());
                CheckoutHeaderDTO model = JsonSerializer.Deserialize<CheckoutHeaderDTO>(content);
                ProcessOrder(model).GetAwaiter().GetResult();
                _channel.BasicAck(evento.DeliveryTag, false);
            };

            _channel.BasicConsume(queue, false, consumer);
            return Task.CompletedTask;
        }

        private async Task ProcessOrder(CheckoutHeaderDTO model)
        {
            OrderHeader order = new()
            {
                UserId = model.UserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                OrderDetails = new List<OrderDetail>(),
                CardNumber = model.CardNumber,
                CouponCode = model.CouponCode,
                CVV = model.CVV,
                DiscountAmount = model.DiscountAmount,
                Email = model.Email,
                ExpiryMonthYear = model.ExpiryMothYear,
                OrderTime = DateTime.Now,
                PurchaseAmount = model.PurchaseAmount,
                PaymentStatus = false,
                Phone = model.Phone,
                DateTime = model.DateTime
            };

            foreach (var details in model.CartDetails)
            {
                OrderDetail detail = new()
                {
                    ProductId = details.ProductId,
                    ProductName = details.Product.Name,
                    Price = details.Product.Price,
                    Count = details.Count
                };

                order.CartTotalItens += details.Count;
                order.OrderDetails.Add(detail);
            }

            await _repository.AddOrder(order);
        }
    }
}
