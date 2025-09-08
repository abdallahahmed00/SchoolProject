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
        IRequestHandler<AddUserCommand, Response<string>>,
        IRequestHandler<UpdateUserCommand, Response<string>>,
        IRequestHandler<DeleteUserCommand, Response<string>>,
        IRequestHandler<ChangeUserPasswordCommand, Response<string>>

    {
        private readonly IMapper _mapper;
        private readonly UserManager<Data.Entities.Identity.User> _UserManager;
        private readonly IValidator<AddUserCommand> _validator;
      //  private readonly IValidator<ChangeUserPasswordCommand> validator;
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
            var CreateResult = await  _UserManager.CreateAsync(identityUser,request.Password);
            if (!CreateResult.Succeeded)
            {
                return BadRequest<string>(" created is failed ");

            }   
            return Created("");
        }

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user =await _UserManager.FindByIdAsync( request.Id.ToString());
            if (user == null)
            {
                return BadRequest<string>("Id Is Not Exist");
            }
            var usermapper = _mapper.Map(request,user);
            var createreuslt = await _UserManager.UpdateAsync(usermapper);
            if (!createreuslt.Succeeded)
            {
                return BadRequest<string>(" Updae is failed ");

            }
            return Success(""); 
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _UserManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
            {
                return BadRequest<string>("Id Is Not Exist");
            }
            var createreuslt = await _UserManager.DeleteAsync(user);
            if (!createreuslt.Succeeded)
            {
                return BadRequest<string>(" Delete is failed ");

            }
            return Success("User deleted success");
        }

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _UserManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
            {
                return BadRequest<string>("Id Is Not Exist");
            }
            var result = await _UserManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded)
            {
                return BadRequest<string>(" change password is failed ");

            }
            return Success("User change password success");
        }
    }
}
 