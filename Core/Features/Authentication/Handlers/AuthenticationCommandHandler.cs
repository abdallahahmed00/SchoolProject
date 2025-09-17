using Azure.Core;
using Core.Basis;
using Core.Features.Authentication.Commands.Models;
using Data.Entities.Identity;
using Data.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authentication.Handlers
{
    public class AuthenticationCommandHandler :ResponseHandler,
        IRequestHandler<SignInCommand,Response<JwtAuthResult>>,
        IRequestHandler<RefreshTokenCommand,Response<JwtAuthResult>>
    {
        private readonly UserManager<Data.Entities.Identity.User> _UserManager;
        private readonly SignInManager<Data.Entities.Identity.User> _SignInManager;
        private readonly IAuthenticationService _AuthenticationService;
        public AuthenticationCommandHandler(UserManager<Data.Entities.Identity.User> UserManager,
            SignInManager<Data.Entities.Identity.User> SignInManager, IAuthenticationService AuthenticationService) 
        {
        _UserManager = UserManager;
            _SignInManager = SignInManager;
            _AuthenticationService = AuthenticationService;
        }

        public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _UserManager.FindByNameAsync(request.UserName);
            if(user==null) 
            {
                return BadRequest<JwtAuthResult>("Not Found this user name ");
            }
            var signresult = _SignInManager.CheckPasswordSignInAsync(user, request.Password, false);
           if (!signresult.IsCompletedSuccessfully)
            {
                return BadRequest<JwtAuthResult>("wrong in password or username");
            }

            var result  =await _AuthenticationService.GetJWTToken(user);
            return Success(result);
        }

        public async Task<Response<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var jwttoken = _AuthenticationService.ReadJWTToken(request.AccessToken);
         
         
            
            var userIdAndExpireDate = await _AuthenticationService.ValidateDetails(jwttoken, request.AccessToken, request.RefreshToken);

            switch (userIdAndExpireDate)
            {
                case ("AlgorithmIsWrong", null): return Unauthorized<JwtAuthResult>();
                case ("TokenIsNotExpired", null): return Unauthorized<JwtAuthResult>();
                case ("RefreshTokenIsNotFound", null): return Unauthorized<JwtAuthResult>();
                case ("RefreshTokenIsExpired", null): return Unauthorized<JwtAuthResult>();
            }
            var (userId, expiryDate) = userIdAndExpireDate;
            var user = await _UserManager.FindByIdAsync(userId);
            if (user==null)
            {
                return NotFound<JwtAuthResult>("not found ");
            }
            var result =await  _AuthenticationService.GetRefreshToken(user, jwttoken,expiryDate ,request.RefreshToken);
            return Success( result);
        }
    }
}
 