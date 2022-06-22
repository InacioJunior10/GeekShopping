using GeekShopping.CartAPI.Data.DTOs;
using GeekShopping.CartAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CartAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }        

        [HttpGet("find-cart/{id}")]        
        public async Task<ActionResult<CartDTO>> FindById(string id)
        {
            var cart = await _repository.FindCartByUserId(id);
            if (cart == null)
                return NotFound();

            return Ok(cart);
        }

        [HttpPost("add-cart")]
        public async Task<ActionResult<CartDTO>> AddCart([FromBody] CartDTO cartDTO)
        {
            var cart = await _repository.SaveOrUpdateCart(cartDTO);
            if (cart == null)
                return NotFound();

            return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<CartDTO>> UpdateCart([FromBody] CartDTO cartDTO)
        {
            var cart = await _repository.SaveOrUpdateCart(cartDTO);
            if (cart == null)
                return NotFound();

            return Ok(cart);
        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<CartDTO>> RemoveCart(int id)
        {
            var status = await _repository.RemoveFromCart(id);
            if (!status)
                return BadRequest();

            return Ok(status);
        }

        [HttpPost("apply-coupon")]
        public async Task<ActionResult<CartDTO>> ApplyCoupon(CartDTO cartDTO)
        {
            var status = await _repository.ApplyCoupon(cartDTO.CartHeader.UserId, cartDTO.CartHeader.CouponCode);
            if (!status)
                return NotFound();

            return Ok(status);
        }

        [HttpDelete("remove-coupon/{userId}")]
        public async Task<ActionResult<CartDTO>> ApplyCoupon(string userId)
        {
            var status = await _repository.RemoveCoupon(userId);
            if (!status)
                return NotFound();

            return Ok(status);
        }
    }
}