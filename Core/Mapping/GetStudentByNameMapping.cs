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
    public class GetStudentByNameMapping :Profile
    {
        public GetStudentByNameMapping()

        {
            CreateMap<Student, GetSingleStudentResponse>()
                    .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));
        }    

    }
}
