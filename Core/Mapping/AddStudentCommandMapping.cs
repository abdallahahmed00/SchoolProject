using AutoMapper;
using Core.Features.Students.Commands.Models;
using Core.Features.Students.Queries.ResultDto;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class AddStudentCommandMapping :Profile
    {
        public AddStudentCommandMapping()
        {

            CreateMap<AddStudentCommand,Student>()
                    .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentId));
        }
    }
}
