using Data.Entities.Identity;
using Data.Filters;
using Data.Helpers;
using Data.Requests;
using Data.Response;
using infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _UserManager;
        private readonly AppDbContext _appDbContext;
        public AuthorizationService(RoleManager<Role> roleManager, UserManager<User> UserManager,
            AppDbContext appDbContext)
        {
            _roleManager = roleManager;
            _UserManager = UserManager;
            _appDbContext = appDbContext;
        }

        public async Task<string> AddRoleAsync(string roleName)
        {
            var idntityrole = new Role();
            idntityrole.Name = roleName;
            var result = await _roleManager.CreateAsync(idntityrole);

            if (result.Succeeded)
            {
                return "Success";
            }
            return "Failed";
        }

        public async Task<bool> IsRoleExistByName(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);

        }

        public async Task<string> EditRoleAsync(EditRoleRequest editRoleRequest)
        {
            var role = await _roleManager.FindByIdAsync(editRoleRequest.Id.ToString());
            if (role == null)
            {
                return "NotFound";
            }
            role.Name = editRoleRequest.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return "Success";
            }
            return "Failed";
        }

        public async Task<string> DeleteRole(int roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null)
            {
                return "NotFound";
            }
            var user =await _UserManager.GetUsersInRoleAsync(role.Name);
            if (user != null ||user.Count()>0)
            {
                return "Used";
            } 
            var result =await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return "Success";
            }
            return "Failed";
        }

        public async Task<bool> IsRoleExistById(int roleId)
        {
            var role =  await _roleManager.FindByIdAsync(roleId.ToString());
            if (role ==null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Role>> GetRolesList()
        {
            var roles =await _roleManager.Roles.ToListAsync();
            return roles;
        }

        public async Task<Role> GetRoleById(int RoleId)
        {
            var role = await _roleManager.FindByIdAsync(RoleId.ToString());
            return role;    
        }

        public async Task<ManageUserRoleResult> GetManageUserRoleData(User user)
        {
            var userRoles = await _UserManager.GetRolesAsync(user);
            var allRoles = await _roleManager.Roles.ToListAsync();

            return new ManageUserRoleResult
            {
                UserId = user.Id,
                roles = allRoles.Select(r => new UserRoles
                {
                    Id = r.Id,
                    Name = r.Name,
                    HasRole = userRoles.Contains(r.Name)
                }).ToList()
            };
          
        }
        public async Task<ManageUserClaimsResult> GetManageUserClaimData(User user)
        {
            var userClaims = await _UserManager.GetClaimsAsync(user);

            return new ManageUserClaimsResult
            {
                UserId = user.Id,
                UserClaims = ClaimStore.Claims.Select(c => new UserClaims
                {
                    Type = c.Type,
                    Value = userClaims.Any(uc => uc.Type == c.Type)
                }).ToList()
            };
        }

        public async Task<string> UpdateUserRoles(UpdateUserRoleRequest request)
        {
            await using var trans = await _appDbContext.Database.BeginTransactionAsync();
            try
            {
                var user = await _UserManager.FindByIdAsync(request.UserId.ToString());
                if (user == null)
                    return "User is null";

                var currentRoles = await _UserManager.GetRolesAsync(user);
                var removeResult = await _UserManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeResult.Succeeded)
                    return "Failed to remove";

                var rolesToAssign = await _roleManager.Roles
                    .Where(r => request.RoleIds.Contains(r.Id)) 
                    .Select(r => r.Name)
                    .ToListAsync();

                var addResult = await _UserManager.AddToRolesAsync(user, rolesToAssign);
                if (!addResult.Succeeded)
                    return "Failed to add";

                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed to update roles";
            }
        }

        public async Task<string> UpdateUserClaims(UpdateUserClaimRequest request)
        {
            var transact = await _appDbContext.Database.BeginTransactionAsync();
            try
            {
                var user = await _UserManager.FindByIdAsync(request.UserId.ToString());
                if (user == null)
                {
                    return "User is null";
                }
                var userClaims = await _UserManager.GetClaimsAsync(user);
                var removeClaimsResult = await _UserManager.RemoveClaimsAsync(user, userClaims);
                if (!removeClaimsResult.Succeeded)
                    return "Failed to remove";
                var claims = request.UserClaims.Where(x => x.Value == true).
                    Select(x => new Claim(x.Type, x.Value.ToString()));

                var addUserClaimResult = await _UserManager.AddClaimsAsync(user, claims);
                if (!addUserClaimResult.Succeeded)
                    return "Failed to add";

                await transact.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await transact.RollbackAsync();
                return "Failed to update roles";
            }

        }
    }
}
