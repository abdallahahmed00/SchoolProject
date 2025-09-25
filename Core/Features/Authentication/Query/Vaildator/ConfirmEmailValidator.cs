using Core.Features.Authentication.Query.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authentication.Query.Vaildator
{
    public class ConfirmEmailValidator :AbstractValidator<ConfirmEmailQuery>
    {
        public ConfirmEmailValidator()
        
        {
            ApplyValidationRules();
        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("code IsEmpty")
                .NotNull().WithMessage("code IsNull");


            RuleFor(x => x.UserId).NotEmpty().WithMessage("UseridIsEmpty")
             .NotNull().WithMessage("UseridIsNull");
        }

    }
}
