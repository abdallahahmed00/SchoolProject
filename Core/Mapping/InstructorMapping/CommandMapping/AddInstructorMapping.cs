using AutoMapper;
using Core.Features.Instrucotrs.Command.Models;
using Core.Features.Instrucotrs.Queries.Result;
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
        public void AddInstructorMapping()
        {
            CreateMap<AddInstructorCommand, Instructor>();
                    




        }
    }
}
