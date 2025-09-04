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
    public class EditNameStudentCommandMapping :Profile
    {
        public EditNameStudentCommandMapping()
        {
        //    CreateMap<EditNameStudentCommand, Student>()
        //              .ForAllMembers(opt => opt.Condition(
        //                  (src, dest, srcMember) => srcMember != null
        //              ));
        }
    }
}
