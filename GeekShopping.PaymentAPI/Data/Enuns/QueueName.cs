using System.ComponentModel;

namespace GeekShopping.PaymentAPI.Data.Enuns
{
    public enum QueueName
    {
        [Description("checkout")]
        Checkout,

        [Description("order_payment_process")]
        OrderPaymentProcess,

        [Description("order_payment_result")]
        OrderPaymentResult
    }
}
