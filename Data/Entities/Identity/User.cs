using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Identity
{
    public class User :IdentityUser<int>
    {
        public User() 
        {
        userRefreshTokens=new HashSet<UserRefreshToken>();    
         }
        public string? FullName { get; set; }
        public string? Address { get; set; }

        public string? Country { get; set; }
   //     [EncryptColumn]
        public string?   Code { get; set; }
        [InverseProperty (nameof(UserRefreshToken.User))]
        public ICollection<UserRefreshToken>userRefreshTokens { get; set; }
    }
}
