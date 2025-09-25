using Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IApplicationUserService
    {
        public Task<string> AddUserAsync(User user,string Password);
    }
}
