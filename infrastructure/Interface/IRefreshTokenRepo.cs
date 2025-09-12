using Data.Entities.Identity;
using Data.Helpers;
using Infrastructure.InfrastructureBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IRefreshTokenRepo :IGenericRepositoryAsync<UserRefreshToken>
    {

    }
}
