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
        private readonly CartIemServices _cartItemServices;
        private readonly IConfiguration _configuration;

        public CartController(CartIemServices   cartIemServices,IConfiguration  configuration) {
            _cartItemServices=cartIemServices;
            _configuration=configuration;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCartItem(CreateCartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                cartItem = await _cartItemServices.CreateCartItem(cartItem);
               return Created(_configuration.GetValue<string>("hostaName")+$"/api/cart/{cartItem.Id}", cartItem);
            }
           return BadRequest(ModelState);
        }
    }
}
