using GeekShopping.Integration.DTOs;

namespace GeekShopping.Web.Models
{
    public class CartHeaderViewModel : CartHeaderDTO
    {
        public decimal PurchaseAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public DateTime DateTime { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiryMothYear { get; set; }
    }
}
