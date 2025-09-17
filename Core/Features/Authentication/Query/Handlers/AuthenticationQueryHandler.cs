using Core.Basis;
using Core.Features.Authentication.Commands.Models;
using Core.Features.Authentication.Query.Models;
using Data.Helpers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authentication.Query.Handlers
{
    public class AuthenticationQueryHandler : ResponseHandler,
        IRequestHandler<AuthorizeUserQuery, Response<string>>
    {
          
   
        private readonly IAuthenticationService _AuthenticationService;
        public AuthenticationQueryHandler(IAuthenticationService AuthenticationService)
        {
           
            _AuthenticationService = AuthenticationService;
        }

        public async Task<Response<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
            var result =await _AuthenticationService.ValidateToken(request.AccessToken);
            if (result == "NotExpired")
            {
                return Success(result);
            }
            return Unauthorized<string>();
        }
    }
}
