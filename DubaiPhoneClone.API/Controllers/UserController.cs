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
