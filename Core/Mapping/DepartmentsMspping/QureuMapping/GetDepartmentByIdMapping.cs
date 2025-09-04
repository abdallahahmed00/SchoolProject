using Core.Features.Departmentcore.Queries.ResultDto;
using Data.Entities;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.DepartmentsMspping
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIdMapping()
            {
            CreateMap<Department, GetDepartmentByIdResponse>().
                ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DName)).
                ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Instructor.Name))
                .ForMember(dest => dest.SubjectsList, opt => opt.MapFrom(src => src.DepartmentSubjects))
                .ForMember(dest => dest.StudentList, opt => opt.MapFrom(src => src.Students))
                .ForMember(dest => dest.InstructorsList, opt => opt.MapFrom(src => src.Instructors));
            CreateMap<DepartmetSubject, SubjectRsponse>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subjects.SubjectName));

            CreateMap<Student, StudentRsponse>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudID))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Instructor, InstrucortRsponse>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InsId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));


        }
    }
}
