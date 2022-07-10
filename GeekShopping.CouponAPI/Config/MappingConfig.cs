using AutoMapper;
using GeekShopping.CouponAPI.Model;
using GeekShopping.Integration.DTOs;

namespace GeekShopping.CouponAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, Coupon>().ReverseMap();                
            });

            return mappingConfig;
        }
    }
}
