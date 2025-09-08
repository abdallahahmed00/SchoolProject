using Core.Features.User.Queries.Results;
using MediatR;
using SchoolProject.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.User.Queries.Models
{
    public class GetListUserQuery :IRequest<PaginatedResult<GetListUserResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } 
       
    }
}
