using Core.Basis;
using Core.Features.Authorization.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authorization.Queries.Models
{
    public class GetRoleByIdQuery :IRequest<Response<GetRoleByIdResponse>>
    {
        public int Id { get; set; }
        public GetRoleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
