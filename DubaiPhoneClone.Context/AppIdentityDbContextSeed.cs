using DubaiPhoneClone.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Context
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User()
                {
                   // Id = "12345",
                    FirstName = "Nada",  
                    LastName = "Assem",
                    PasswordHash= "Na#812000",
                    UserName = "nadaassem81@gmail.com",
                    PhoneNumber = "01100432184",
                    Email = "nadaassem81@gmail.com",
                    Address = "Qena",
                    City = "Qena",
                };

                var result = await userManager.CreateAsync(user, user.PasswordHash);

                if (result.Succeeded)
                {
                    var adminRoleExists = await roleManager.RoleExistsAsync("Admin");
                    if (!adminRoleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole("Admin"));
                    }

                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
