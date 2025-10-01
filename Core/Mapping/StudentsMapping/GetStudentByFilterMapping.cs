    using AutoMapper;
    using Core.Features.Students.Queries.Models;
    using Core.Features.Students.Queries.ResultDto;
    using Data.Entities;
    using Microsoft.AspNetCore.Routing.Constraints;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Core.Mapping.StudentMapping
    {
        public class GetStudentByFilterMapping :Profile
        {
            public GetStudentByFilterMapping() 
            {
                CreateMap<Student, GetStudentByFilterResult>()
                    .ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.StudID))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                        .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DName))
                            .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Department.DID))
                                .ForMember(dest => dest.SubjectList, opt => opt.MapFrom(src => src.StudentSubject))
                       .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));




                CreateMap<StudentSubject, SubStdResponse>()
    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subject.SubjectName))
                    .ForMember(dest => dest.Grade, opt => opt.MapFrom(src => src.grade));
               
            }
        }
    }
