using Data.Entities.Identity;
using Data.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.AuthServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AuthServices.Implementation
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _httpContextAccessor= httpContextAccessor;
            _userManager = userManager;  
        }
        public async Task<User> GetUserAsync()
        {
            var userid = GetUserId();
            var user =await _userManager.FindByIdAsync(userid.ToString());
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }
            return user;
        }

        public int GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.
                SingleOrDefault(claims => claims.Type == nameof(UserClaimModel.Id)).Value;
            if(userId==null)
            {
                throw new UnauthorizedAccessException();
            }
            return int.Parse( userId);
        }

        public async Task<List<string>> GetCurrentUserRolesAsync()
        {
            var user =await GetUserAsync();
            var roles =await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }
    }
}
