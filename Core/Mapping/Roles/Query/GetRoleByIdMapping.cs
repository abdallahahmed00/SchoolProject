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

        public void GetRoleByIdMapping()
        {
            CreateMap<Role,GetRoleByIdResponse>();
        }
    }
}
