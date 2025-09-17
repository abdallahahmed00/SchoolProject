using AutoMapper;
using Core.Basis;
using Core.Features.Authorization.Queries.Models;
using Data.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authorization.Queries.Handlers
{
    public class ClaimQueryHandlers : ResponseHandler,
        IRequestHandler<ManageUserClaimQuery, Response<ManageUserClaimsResult>>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly UserManager<Data.Entities.Identity.User> _UserManager;
        public ClaimQueryHandlers(IAuthorizationService authorizationService, IMapper mapper,
             UserManager<Data.Entities.Identity.User> UserManager)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
            _UserManager = UserManager;
        }

        public async Task<Response<ManageUserClaimsResult>> Handle(ManageUserClaimQuery request, CancellationToken cancellationToken)
        {
            var user = await _UserManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                return NotFound<ManageUserClaimsResult>("cant find user");
            }
            var result = await _authorizationService.GetManageUserClaimData(user);
            return Success(result);
        }
    }
}
