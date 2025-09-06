using Core.Features.Instrucotrs.Queries.Result;
using Data.Entities;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.InstructorMapping
{
    public partial class InstructorProfile
    {
        public void GetAllInstructorMapping() 
        {
            CreateMap<Instructor, GetAllInstrucorResponse>()
              .ForMember(dest => dest.InsId, opt => opt.MapFrom(src => src.InsId))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
              .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.department)) 
              .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.Ins_Subjects));
            CreateMap<Department, DepartmentResponse>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DName));
            CreateMap<Ins_Subject, InsSub>().
                ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.SubjectName));
        }
    }
}
