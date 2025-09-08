using Core.Features.User.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.User.Commands.Validations
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationsRules();
        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("FullNameIsEmpty")
                .NotNull().WithMessage("FullNameIsNull");


            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserNameIsEmpty")
             .NotNull().WithMessage("UserNameIsNull");


        }

        public void ApplyCustomValidationsRules()
        {

        }
    
    }
}
