using Core.Features.Authentication.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authentication.Commands.Validations
{
    public class SignInValidator : AbstractValidator<SignInCommand>
    {
        public SignInValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationsRules();
        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password IsEmpty")
                .NotNull().WithMessage("Password IsNull");


            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserNameIsEmpty")
             .NotNull().WithMessage("UserNameIsNull");
        }

        public void ApplyCustomValidationsRules()
        {

        }
    }
}