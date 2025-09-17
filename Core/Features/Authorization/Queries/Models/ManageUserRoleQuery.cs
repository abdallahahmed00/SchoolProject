using Core.Basis;
using Data.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authorization.Queries.Models
{
    public class ManageUserRoleQuery :IRequest<Response<ManageUserRoleResult>>
    {
        public int UserId { get; set; }
        public ManageUserRoleQuery(int id)
        {
            UserId=id;  
        }
    }
}
