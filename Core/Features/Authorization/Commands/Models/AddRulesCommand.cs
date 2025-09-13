using Core.Basis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authorization.Commands.Models
{
    public class AddRulesCommand :IRequest<Response<string>>
    {
        public string RoleName { get; set; }
    }
}
