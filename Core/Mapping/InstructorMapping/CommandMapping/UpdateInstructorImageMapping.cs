using AutoMapper;
using Core.Features.Instrucotrs.Command.Models;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.InstructorMapping
{
    public partial class InstructorProfile : Profile
    {
        public void UpdateInstructorImageMapping()
        {
            CreateMap<UpdateInstructorImageCommands, Instructor>()
                .ForMember(dest => dest.InsId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Image, opt => opt.Ignore());
            }
    }
}
