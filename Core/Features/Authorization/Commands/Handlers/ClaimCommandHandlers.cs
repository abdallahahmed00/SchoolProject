using Core.Basis;
using Core.Features.Authorization.Commands.Models;
using MediatR;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authorization.Commands.Handlers
{
    internal class ClaimCommandHandlers : ResponseHandler,
        IRequestHandler<UpdateUserClaimCommand, Response<string>>
     
    {
        private readonly IAuthorizationService _authorizationService;
        public ClaimCommandHandlers(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<Response<string>> Handle(UpdateUserClaimCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserClaims(request);
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
