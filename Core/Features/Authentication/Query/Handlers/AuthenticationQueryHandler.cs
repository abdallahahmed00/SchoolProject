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
        IRequestHandler<AuthorizeUserQuery, Response<string>>,
        IRequestHandler<ConfirmEmailQuery, Response<string>>,
        IRequestHandler<ConfirmResetPasswordQuery, Response<string>>
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

        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var confirmEmail = await _AuthenticationService.ConfirmEmail(request.UserId, request.Code);
            if (confirmEmail == "ErrorWhenConfirmEmail")
                return BadRequest<string>();
            return Success<string>("");
        }

        public async Task<Response<string>> Handle(ConfirmResetPasswordQuery request, CancellationToken cancellationToken)
        {
            var result =await _AuthenticationService.ConfirmResetPassword(request.Code,request.Email);
            switch (result)
            {
                case "UserNotFound": return BadRequest<string>("UserNotFound");
                case "Failed": return BadRequest<string>("Failed");
                case "Success": return Success<string>("Success");
                default: return BadRequest<string>("");
            }
        }
    }
}
