using Core.Basis;
using Data.Filters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authorization.Commands.Models
{
    public class UpdateUserRolesCommand : UpdateUserRoleRequest, IRequest<Response<string>>
    {
        
    }
}
