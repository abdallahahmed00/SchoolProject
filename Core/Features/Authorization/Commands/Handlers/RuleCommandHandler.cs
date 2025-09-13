using Core.Basis;
using Core.Features.Authorization.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authorization.Commands.Handlers
{
    public class RuleCommandHandler :ResponseHandler ,
        IRequestHandler<AddRulesCommand,Response<string>>
    {
        private readonly IAuthorizationService _authorizationService;
        public RuleCommandHandler(IAuthorizationService authorizationService )
        {
            _authorizationService  = authorizationService; 
        }

        public async Task<Response<string>> Handle(AddRulesCommand request, CancellationToken cancellationToken)
        {
            var result =await _authorizationService.AddRoleAsync(request.RoleName);
            if(result== "Success")
                    {
                return Success("");
            }
            return BadRequest<string>("Added failed"); 
        }

    }
}
