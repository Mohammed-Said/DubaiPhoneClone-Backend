using DubaiPhone.DTOs.cartDTOs;
using DubaiPhoneClone.Application.services.cartitems;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DubaiPhoneClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartIemServices _cartItemServices;
        private readonly IConfiguration _configuration;

        public CartController(ICartIemServices cartIemServices, IConfiguration configuration)
        {
            _cartItemServices = cartIemServices;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCartItem(CreateCartItemDTO cartItem)
        {
            if (ModelState.IsValid)
            {
                cartItem = await _cartItemServices.AddCartItem(cartItem);
                return Created(_configuration.GetValue<string>("hostaName") + $"/api/cart/{cartItem}", cartItem);
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetUserCart")]
        public async Task<IActionResult> GetUserCart(string userId)
        {
            var cart = await _cartItemServices.GetUserCart(userId);
            if (cart == null)
                return BadRequest();
            return Ok(cart);

        }
        [HttpGet("GetCartProductsByUser")]
        public async Task<IActionResult> GetCartProducts(string userId)
        {
            var cart = await _cartItemServices.GetCartProducts(userId);
            if (cart == null)
                return BadRequest();
            return Ok(cart);
        }

        [HttpGet("GetCartProducts")]
        public async Task<IActionResult> GetCartProducts([FromQuery]int[] ids)
        {
            var cart = await _cartItemServices.GetCartProducts(ids);
            if (cart == null)
                return BadRequest();
            return Ok(cart);
        }

    }
}
