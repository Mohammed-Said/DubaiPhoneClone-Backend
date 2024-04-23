using Dashboard.Models;
using DubaiPhone.DTOs.userDTOs;
using DubaiPhoneClone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Controllers
{
	public class UserController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public UserController(UserManager<User> userManager , RoleManager<IdentityRole> roleManager) {
			_userManager = userManager;
			_roleManager = roleManager;
		}

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModels = users.Select(u => new UserViewModel
            {
                Id = u.Id,
                UserName = u.UserName,
				PhoneNumber = u.PhoneNumber ,
                Email = u.Email,
                Roles = _userManager.GetRolesAsync(u).Result
            }).ToList();

            return View(userViewModels);
        }

        public async Task<IActionResult> Edit(string Id)
		{
			var user = await _userManager.FindByIdAsync(Id);
			var AllRoles = await _roleManager.Roles.ToListAsync();
			var viewModel = new UserRoleViewModel
            {
				UserId = user.Id,
				UserName = user.UserName,
				Roles = AllRoles.Select(r => new RoleViewModel
				{
					Id = r.Id,
					Name = r.Name,
					IsSelected = _userManager.IsInRoleAsync(user, r.Name).Result

				}).ToList(),
			};
			return View(viewModel);

        }

		[HttpPost]
		public async Task<IActionResult> Edit(UserRoleViewModel model)
		{
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user != null)
            {
                // Check if the user has a security stamp, if not, generate one
                if (string.IsNullOrEmpty(user.SecurityStamp))
                {
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    await _userManager.UpdateAsync(user);
                }

                var userRoles = await _userManager.GetRolesAsync(user);

                foreach (var role in model.Roles)
                {
                    if (userRoles.Any(r => r == role.Name) && !role.IsSelected)
                    {
                        await _userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                    if (!userRoles.Any(r => r == role.Name) && role.IsSelected)
                    {
                        await _userManager.AddToRoleAsync(user, role.Name);
                    }
                }
            }

            return RedirectToAction("Index");

        }
    }
}
 