using Data.Entities.Identity;
using Data.Filters;
using Data.Requests;
using Data.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IAuthorizationService
    {
        public Task<string> AddRoleAsync(string roleName);
        public Task<string> EditRoleAsync(EditRoleRequest editRoleRequest);
        public Task<bool> IsRoleExistByName(string roleName);
        public Task<bool> IsRoleExistById(int roleId);
        public Task<string> DeleteRole(int roleId);
        public Task<List<Role>> GetRolesList();
        public Task<Role> GetRoleById(int RoleId);
        public Task<ManageUserRoleResult> GetManageUserRoleData(User User);
        public Task<string> UpdateUserRoles(UpdateUserRoleRequest request);
        public Task<ManageUserClaimsResult> GetManageUserClaimData(User user);

        public Task<string> UpdateUserClaims(UpdateUserClaimRequest request);

    }
}
