using Core.Basis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authentication.Query.Models
{
    public class AuthorizeUserQuery :IRequest<Response<string>>
    {
        public string AccessToken { get; set; }
    }
}
