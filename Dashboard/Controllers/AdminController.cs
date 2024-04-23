using DubaiPhone.DTOs.AccountDTO;
using DubaiPhoneClone.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dashboard.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AdminController(UserManager<User> userManager, SignInManager<User> signInManager )
        {

          _userManager = userManager;
           _signInManager = signInManager;
        }
        public async Task<IActionResult> Login()
        {
           return View();  
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", "Email Is Invalid");
                return RedirectToAction(nameof(Login));
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (!result.Succeeded || !await _userManager.IsInRoleAsync(user, "Admin"))
            {
                ModelState.AddModelError(string.Empty, "you Are Not Authorized");
                return RedirectToAction(nameof(Login));
            }
            else
                return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
