using Core.Features.Authentication.Commands.Models;
using Core.Features.Authentication.Query.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authentication.Query.Vaildator
{
    public class ConfirmRsestPasswordQueryValidation : AbstractValidator<ConfirmResetPasswordQuery>
    {
        public ConfirmRsestPasswordQueryValidation()
        {
            ApplyValidationRules();
        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code IsEmpty")
                .NotNull().WithMessage("Code IsNull");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Password IsEmpty")
             .NotNull().WithMessage("Password IsNull");




        }

    }
}
