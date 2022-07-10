using GeekShopping.Integration.DTOs;

namespace GeekShopping.OrderAPI.Messages
{
    public class CheckoutHeaderOrderDTO : CheckoutHeaderDTO
    {        
        public IEnumerable<CartDetailDTO>? CartDetails { get; set; }
    }
}
