using Core.Basis;
using MediatR;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Departmentcore.Commands.models
{
    public class UpdateManagerDepartmentCommand : IRequest<Response<string>>
    {
        public int DID { get; set; }
        public int ManagerId
        {
            get; set;
        }
    }
}
