using AutoMapper;
using Core.Basis;
using Core.Features.Authorization.Queries.Models;
using Core.Features.Authorization.Queries.Results;
using Data.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Service.Abstract;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authorization.Queries.Handlers
{
    public class RuleQueryHandler :ResponseHandler,
        IRequestHandler<GetRoleListQuery,Response< List<GetListRolesResponse>>>,
        IRequestHandler<GetRoleByIdQuery,Response< GetRoleByIdResponse>>,
        IRequestHandler<ManageUserRoleQuery, Response< ManageUserRoleResult>>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly UserManager<Data.Entities.Identity. User> _UserManager;
        public RuleQueryHandler(IAuthorizationService authorizationService, IMapper mapper,
             UserManager<Data.Entities.Identity.User> UserManager)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
            _UserManager = UserManager;
        }

        public async Task<Response<List<GetListRolesResponse>>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationService.GetRolesList();
            var result = _mapper.Map<List< GetListRolesResponse>>(roles);
            return Success(result);  
        }

        public async Task<Response<GetRoleByIdResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _authorizationService.GetRoleById(request.Id);
            if (role==null)
            {
                return NotFound<GetRoleByIdResponse>("Not Found this id");
            }
            var result = _mapper.Map<GetRoleByIdResponse>(role);
           return Success(result);
        }

        public async Task<Response<ManageUserRoleResult>> Handle(ManageUserRoleQuery request, CancellationToken cancellationToken)
        {
            var role =await _UserManager.FindByIdAsync(request.UserId.ToString());
            if (role==null)
            {
                return NotFound<ManageUserRoleResult>("Not found this user");
            }
            var result = await _authorizationService.GetManageUserRoleData(role);
            return Success(result);
        }
    }
}
