using Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seedor
{
    public static class UserSeedor
    {
        public static async Task SeedAsync(UserManager<User>_userManager)
        {
            var Users = await _userManager.Users.CountAsync();
            if(Users <=0)
            {
                var defultuser = new User()
                {
                    UserName = "admin",
                    Email = "admin@project.com",
                    FullName = "schoolProject",
                    Country = "Egypt",
                    PhoneNumber = "123456",
                    Address = "Egypt",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                await _userManager.CreateAsync(defultuser, "Aa123456@");
                await _userManager.AddToRoleAsync(defultuser, "Admin");
            }
        }
    }

}
