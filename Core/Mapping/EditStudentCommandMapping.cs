using AutoMapper;
using Core.Features.Students.Commands.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class EditStudentCommandMapping :Profile
    {
        public EditStudentCommandMapping()
        {

            CreateMap<EditStudentCommand, Student>()
                    .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentId))
                    .ForMember(dest => dest.StudID, opt => opt.MapFrom(src=>src.Id));
        }
    }
}
