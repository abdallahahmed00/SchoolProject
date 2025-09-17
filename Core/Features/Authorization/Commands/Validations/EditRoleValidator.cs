using Core.Features.Authorization.Commands.Models;
using FluentValidation;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authorization.Commands.Validations
{
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {
        private readonly IAuthorizationService _authorizationService;
        public EditRoleValidator(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("IT Is Empty")
                .NotNull().WithMessage("Not Be Null");
        }
        public void ApplyCustomValidationRules()
        {

        }

    }
}

