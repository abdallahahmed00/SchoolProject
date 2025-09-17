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
    public class ManageUserClaimQuery :IRequest<Response<ManageUserClaimsResult>>
    {
        public int UserId { get; set; } 
        public ManageUserClaimQuery(int id )
        {
            UserId = id;    
        }
    }
}
