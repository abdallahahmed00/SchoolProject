using AutoMapper;
using Core.Basis;
using Core.Features.Instrucotrs.Queries.Result;
using Core.Features.User.Commands.Models;
using Core.Features.User.Queries.Models;
using Core.Features.User.Queries.Results;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.User.Queries.Handler
{
    public class UserQuerHandler:ResponseHandler ,
        IRequestHandler<GetListUserQuery,PaginatedResult< GetListUserResponse>>,
        IRequestHandler<GetUserByIdQuery,Response<GetUserByIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Data.Entities.Identity.User> _UserManager;
        public UserQuerHandler(IMapper mapper, UserManager<Data.Entities.Identity.User> UserManager  )
        {
            _UserManager = UserManager;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<GetListUserResponse>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
        {
            var users =  _UserManager.Users.AsQueryable();
            var PaginatedList =await _mapper.ProjectTo<GetListUserResponse>(users)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return PaginatedList;
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _UserManager.Users.FirstOrDefaultAsync(u => u.Id == request.Id);
            if (user == null)
            {
                return NotFound<GetUserByIdResponse>("Not Found");
            }
            var usermapper = _mapper.Map<GetUserByIdResponse>(user);
            return Success(usermapper);
        }

       

    }
}
