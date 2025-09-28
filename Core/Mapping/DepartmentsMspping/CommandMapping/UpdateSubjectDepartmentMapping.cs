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
        public void UpdateSubjectDepartmentMapping()
        {
           
            CreateMap<UpdateSubjectInDepartmentCommand, Department>()
          .ForMember(dest => dest.DepartmentSubjects,
                     opt => opt.MapFrom(src => src.SubjectsId));

            CreateMap<UpdateSubjects, DepartmetSubject>()
                .ForMember(dest => dest.SubID, opt => opt.MapFrom(src => src.SubId))
                .ForMember(dest => dest.DID, opt => opt.Ignore());
        }

    }
}
