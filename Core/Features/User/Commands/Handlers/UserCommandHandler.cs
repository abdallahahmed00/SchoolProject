using AutoMapper;
using Core.Basis;
using Core.Features.User.Commands.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.User.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
        IRequestHandler<AddUserCommand, Response<string>>

    {
        private readonly IMapper _mapper;
        private readonly UserManager<Data.Entities.Identity.User> _UserManager;
        private readonly IValidator<AddUserCommand> _validator;
        public UserCommandHandler (IMapper mapper, UserManager<Data.Entities.Identity.User> UserManager,
            IValidator<AddUserCommand> validator)
        {
         _UserManager=UserManager;
            _mapper = mapper; 
            _validator = validator;
        }
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
               ValidationResult result = await _validator.ValidateAsync(request, cancellationToken);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            return BadRequest<string>(string.Join(" , ", errors));
        }

            var user =await _UserManager.FindByEmailAsync(request.Email);
            if(user!=null)
            {
                return BadRequest<string>("Email Is Exist");
            }
            var userByName = await _UserManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return BadRequest<string>("UserName Is Exist");
            }
            var identityUser = _mapper.Map < Data.Entities.Identity.User > (request);
            var CreateResult = _UserManager.CreateAsync(identityUser,request.Password);
            if (!CreateResult.IsCompletedSuccessfully)
            {
                return BadRequest<string>(" created is failed ");

            }
            return Created("");
        }
    }
}
 