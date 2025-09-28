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
        public void AddDepartmentMapping() 
        
        {
            CreateMap<AddDepartmentCommand, Department>();
        }
    }
}
