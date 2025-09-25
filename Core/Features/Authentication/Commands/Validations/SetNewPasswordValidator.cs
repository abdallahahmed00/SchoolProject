using Core.Features.Authentication.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authentication.Commands.Validations
{
    public class SetNewPasswordValidator :AbstractValidator<SetNewPasswordCommand>
    {
        public SetNewPasswordValidator()
        {
            ApplyValidationRules();
        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password IsEmpty")
                .NotNull().WithMessage("Password IsNull");
            RuleFor(x => x.Confirmpassword).NotEmpty().WithMessage("Confirm Password IsEmpty")
                .NotNull().WithMessage("Confirm Password IsNull");



            RuleFor(x => x.Email).NotEmpty().WithMessage("Email IsEmpty")
             .NotNull().WithMessage("Email IsNull");
        }

    }
}
