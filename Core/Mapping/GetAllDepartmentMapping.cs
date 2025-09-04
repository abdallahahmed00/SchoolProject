using AutoMapper;
using Core.Features.Departmentcore.Queries.ResultDto;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class GetAllDepartmentMapping :  Profile
    {
        public GetAllDepartmentMapping()
        {
            CreateMap<Department, GetListDepartmentDto>()
                .ForMember(dest => dest.StudentList, opt => opt.MapFrom(src => src.Students))
                .ForMember(dest => dest.DepartmentSubjectsList, opt => opt.MapFrom(src => src.DepartmentSubjects))
                .ForMember(dest => dest.InstructorsList, opt => opt.MapFrom(src => src.Instructors))
                .ForMember(dest => dest.Instructor, opt => opt.MapFrom(src => src.Instructor));
        }
    }
}
