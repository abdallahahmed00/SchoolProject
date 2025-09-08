using AutoMapper;
using Core.Features.User.Commands.Models;
using Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.AppUserMapping
{
    public partial class ApplicationUserProfile : Profile
    {
        public void UpdateUserMapping()
        {
            CreateMap<UpdateUserCommand,User>();
        }
            
            
    }
}
