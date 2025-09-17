using AutoMapper;
using Core.Features.Authorization.Queries.Results;
using Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Roles
{
    public partial class Rolesprofile 
    {
      public void GetListMapping()
        
        {
            CreateMap<Role, GetListRolesResponse>();
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        
        }

    }
}
