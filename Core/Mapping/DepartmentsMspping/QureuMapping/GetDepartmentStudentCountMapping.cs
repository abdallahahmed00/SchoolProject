using AutoMapper;
using Core.Features.Departmentcore.Queries.ResultDto;
using Data.Entities.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.DepartmentsMspping
{
    public partial class DepartmentProfile 
    {
        public void GetDepartmentStudentCountMapping()
        {
            CreateMap<ViewDepartment, GetDepartmentStudentCountResult>()
                     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DName))
                .ForMember(dest => dest.CountStudent, opt => opt.MapFrom(src => src.CountStudent));
        }
    }
}
    