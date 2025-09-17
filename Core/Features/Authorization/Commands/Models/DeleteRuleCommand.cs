using Core.Basis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authorization.Commands.Models
{
    public class DeleteRuleCommand :IRequest<Response<string>>
    {
        public int RoleId { get; set; }
        public DeleteRuleCommand(int id)
        {
            RoleId=id;  
        }
    }
}
