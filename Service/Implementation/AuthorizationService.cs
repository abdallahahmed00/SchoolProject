using Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<Role> _roleManager;
        public AuthorizationService(RoleManager<Role> roleManager)
        {
            _roleManager=roleManager;
        }

        public async Task<string> AddRoleAsync(string roleName)
        {
            var idntityrole = new Role();
            idntityrole.Name = roleName;
            var result =await _roleManager.CreateAsync(idntityrole);

            if (result.Succeeded)
            {
                return "Success";
            }
            return "Failed"; 
        }

        public async Task<bool> IsRoleExist(string roleName)
        {
           return await _roleManager.RoleExistsAsync(roleName);

        }
    }
}
