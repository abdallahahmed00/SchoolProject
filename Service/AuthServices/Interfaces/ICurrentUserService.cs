using Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AuthServices.Interfaces
{
    public interface ICurrentUserService
    {
        public Task<User> GetUserAsync();
        public int GetUserId();
        public Task<List<string>> GetCurrentUserRolesAsync();
    }
}
