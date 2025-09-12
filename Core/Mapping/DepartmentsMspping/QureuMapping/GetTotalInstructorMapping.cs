using AutoMapper;
using Core.Features.Departmentcore.Queries.ResultDto;
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
        public void GetTotalInstructorMapping ()
        {
            CreateMap<Department, GetTotalInstructorInDepartmentResponse>()
                .ForMember(dest => dest.TotalNumber, opt => opt.MapFrom(src => src.Instructors.Count))
                .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DID));

        }
    }
}
