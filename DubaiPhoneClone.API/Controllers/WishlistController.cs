using DubaiPhone.DTOs.WishlistDTOs;
using DubaiPhoneClone.Application.services.WishlistService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DubaiPhoneClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }
        [HttpPost]
        public async Task<IActionResult> UpdateWishlist(int itemId, string userId)
        {
            await _wishlistService.UpdateWishlist(itemId, userId);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<WishlistDto>>> GetUserWishLilist(string userId)
        {
            var wishlist =await _wishlistService.GetWishlistItems(userId);
            if (wishlist == null)
            {
                return BadRequest();
            }
            return Ok(wishlist);
        }
    }
}
