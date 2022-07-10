using GeekShopping.Integration.DTOs;

namespace GeekShopping.CartAPI.Messages
{
    public class CheckoutHeaderCartDTO : CheckoutHeaderDTO
    {                
        public IEnumerable<CartDetailDTO>? CartDetails { get; set; }
    }
}
