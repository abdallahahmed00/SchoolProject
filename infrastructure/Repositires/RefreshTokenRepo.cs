using Data.Entities;
using Data.Entities.Identity;
using Data.Helpers;
using infrastructure.Data;
using Infrastructure.InfrastructureBase;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositires
{
    public class RefreshTokenRepo : GenericRepositoryAsync <UserRefreshToken> , IRefreshTokenRepo
    {
        private readonly DbSet<UserRefreshToken> _RefreshToken;
        public RefreshTokenRepo(AppDbContext context) : base(context)
        {
            _RefreshToken = context.Set<UserRefreshToken>();
        }

    }
}
