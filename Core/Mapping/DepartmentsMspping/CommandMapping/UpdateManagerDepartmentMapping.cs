using AutoMapper;
using Core.Features.Departmentcore.Commands.models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.DepartmentsMspping
{
    public partial class DepartmentProfile 
    {

        public void UpdateManagerDepartmentMapping()
        {
            CreateMap<UpdateManagerDepartmentCommand, Department>()
           .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DID))
           .ForMember(dest => dest.InsManager, opt => opt.MapFrom(src => src.ManagerId));

        }
    }
}
