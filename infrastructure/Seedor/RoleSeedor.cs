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
    public static  class RoleSeedor
    {
        public static async Task SeedAsync(RoleManager<Role> _roleManager)
        {
            var rolesCount = await _roleManager.Roles.CountAsync();
            if (rolesCount <= 0)
            {

                await _roleManager.CreateAsync(new Role()
                {
                    Name = "Admin"
                });
                await _roleManager.CreateAsync(new Role()
                {
                    Name = "User"
                });
            }
        }
    }
}
