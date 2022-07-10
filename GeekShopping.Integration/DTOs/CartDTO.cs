namespace GeekShopping.Integration.DTOs
{
    public class CartDTO
    {
        public CartHeaderDTO CartHeader { get; set; }

        public IEnumerable<CartDetailDTO>? CartDetails { get; set; }
    }
}
