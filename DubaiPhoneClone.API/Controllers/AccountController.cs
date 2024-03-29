using DubaiPhone.DTOs.userDTOs;
using DubaiPhoneClone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DubaiPhoneClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {

            this._userManager = userManager;
            this._signInManager = signInManager;
            this._configuration = configuration;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUpAsync(SignUpDTO model)
        {
            if (ModelState.IsValid)
            {
                var userName = await _userManager.FindByNameAsync(model.Username);
                var userEmail = await _userManager.FindByEmailAsync(model.Email);
                if (userName == null && userEmail == null)
                {
                    var user = new User()
                    {
                        Email = model.Email,
                        UserName = model.Username,
                        PasswordHash = model.Password
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (!result.Succeeded) return BadRequest(result.Errors);
                    return Ok();
                }
                else
                {
                    if (userName != null)
                        return BadRequest(error: "Sorry User Name is Exisit");
                    return BadRequest(error: "Sorry Email is Exisit");

                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user is null)
                    return Unauthorized();


                bool isLogin = await _userManager.CheckPasswordAsync(user, model.Password);

                if (!isLogin)
                    return Unauthorized();

                var claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Name, user.UserName!));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                claims.Add(new Claim(ClaimTypes.Email, user.Email));

                if (user.PhoneNumber is not null)
                    claims.Add(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber));

                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],//Provider (API)
                    audience: _configuration["JWT:ValidAudiance"],//Consumer (Angular)
                    claims,
                    expires: DateTime.Now.AddDays(15),
                    signingCredentials: signingCredentials
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expitation = token.ValidTo,
                    status = 200,
                });

            }
            return Unauthorized();
        }

    }
}
