using GeekShopping.Integration.DTOs;

namespace GeekShopping.CartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDTO> GetCoupon(string couponCode, string token);
    }
}
