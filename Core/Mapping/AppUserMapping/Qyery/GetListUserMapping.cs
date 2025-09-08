using Core.Features.User.Queries.Results;
using Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.AppUserMapping
{
    public partial class ApplicationUserProfile
    {
    
        public void GetListUserMapping()
        {
            CreateMap<User, GetListUserResponse>();
        }

    }
}
