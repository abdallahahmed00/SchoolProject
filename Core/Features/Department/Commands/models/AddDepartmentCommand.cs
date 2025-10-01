using Core.Basis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Departmentcore.Commands.models
{
    public class AddDepartmentCommand :IRequest<Response<string>>
    {
        public string DName { get; set; }

    }
}
