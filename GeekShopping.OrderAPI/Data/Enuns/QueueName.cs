using System.ComponentModel;

namespace GeekShopping.OrderAPI.Data.Enuns
{
    public enum QueueName
    {
        [Description("checkout")]
        Checkout,

        [Description("order_payment_process")]
        OrderPaymentProcess
    }
}
