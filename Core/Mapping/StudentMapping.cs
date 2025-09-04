using AutoMapper;
using Core.Features.Students.Queries.ResultDto;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public  class StudentMapping :Profile
    {
        public StudentMapping() 
        {
            CreateMap<Student, GetListStudentDto>()
                    .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));
        }

    }
}
 