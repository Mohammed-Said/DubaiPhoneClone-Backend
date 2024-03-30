using DubaiPhone.DTOs.cartDTOs;
using DubaiPhone.DTOs.userDTOs;
using DubaiPhoneClone.Application.services.userServices;
using DubaiPhoneClone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DubaiPhoneClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserServices _userServices;
        IConfiguration _configuration;
        public UserController(UserServices  userServices,IConfiguration configuration) {
            _userServices = userServices;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult>Registeration(CreateUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            GetUser createdUser = await _userServices.CreateUser(user);
                if(createdUser == null)
            {
                return BadRequest("probably this email is used already go to log in");
            }
            return Created(_configuration.GetValue<string>("hostaName") + $"/api/user/{createdUser.Id}", createdUser);
        }
        
        [HttpPatch("additemtomywishlist/{itemId:int}")]
        public async Task<IActionResult> addToWishList(int itemId)
        {
            int userId = 0;//add userId from claims
            bool sucess = await _userServices.AddLovedItem(itemId,userId);
            if (sucess)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("orders/{userid:int}")]
        public async Task<IActionResult> GetUserOrders(int userid)
        {
            List<Order>orders=await _userServices.GetCustomerOrders(userid);
            if (orders == null)
            {
                return BadRequest();
            }
            return Ok(orders);
        }
        [HttpGet("myorders")]
        public async Task<IActionResult> GetMyOrders()
        {
            int userId=0;//get from claims
            return Ok(_userServices.GetCustomerOrders(userId));
        }
        [HttpGet("myprofile")]
        public  async Task<IActionResult> getMydata()
        {
            int myId=0;//get from claims
            return Ok(_userServices.GetUserByID(myId));
        }
        [HttpPut("myprofile")]
        public async Task<IActionResult> UpdateMydata(UpdateUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //check it is the sending user object from claims
            //check old password  is  right
            return Ok(_userServices.UpdateUser(user));
        }

    }
}
