using Core.Basis;
using Core.Features.User.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.User.Queries.Models
{
    public class GetUserByIdQuery :IRequest <Response<GetUserByIdResponse>>
    {
        public int Id { get; set; }
        public GetUserByIdQuery (int id )
        {
            this.Id = id;
        }

    }
}
