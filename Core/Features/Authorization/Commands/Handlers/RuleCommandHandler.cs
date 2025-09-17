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
        IRequestHandler<AddRulesCommand,Response<string>>,
        IRequestHandler<EditRoleCommand,Response<string>>,
        IRequestHandler<DeleteRuleCommand,Response<string>>,
        IRequestHandler<UpdateUserRolesCommand,Response<string>>
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

        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.EditRoleAsync(request);
            if (result == "NotFound")
            {
                return NotFound<string>();
            }
            else if (result == "Success")
            {
                return Success<string>("Edit Success");
            }
            else
              return  BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(DeleteRuleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.DeleteRole(request.RoleId);
            if (result == "NotFound")
            {
                return NotFound<string>();
            }
            else if (result=="Used")
                {
                return BadRequest<string>("This role is used");
            }
            else if (result == "Success")
            {
                return Success<string>("Deleted Success");
            }
            else
                return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            var result =await _authorizationService.UpdateUserRoles(request);
            switch (result)
            {
                case "User is null": return NotFound<string>("Not found this user");
                case "Failed to remove": return BadRequest<string>("failed to remove");
                case "Failed to add": return BadRequest<string>("failed to add");
                case "Failed to update roles": return BadRequest<string>("failed to update");
                case "Success": return Success<string>("Updated Roles Successfully");
            }
            return Success(result);
        }
    }
}
