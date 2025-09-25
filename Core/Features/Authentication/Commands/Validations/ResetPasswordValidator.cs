using Core.Features.Authentication.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authentication.Commands.Validations
{
    public class ResetPasswordValidator :AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordValidator()
        {
            ApplyValidationRules();
        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Password IsEmpty")
                .NotNull().WithMessage("Password IsNull");


     
        }
    }
}
