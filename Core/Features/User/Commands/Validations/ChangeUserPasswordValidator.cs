using Core.Features.User.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.User.Commands.Validations
{
    public class ChangeUserPasswordValidator :AbstractValidator<ChangeUserPasswordCommand>
    {
        public ChangeUserPasswordValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("iD IsEmpty")
.NotNull().WithMessage("Id IsNull");
            RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage("Password IsEmpty")
.NotNull().WithMessage("Password IsNull");
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("Password IsEmpty")
.NotNull().WithMessage("Password IsNull");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.NewPassword).
                WithMessage("ConfirmPassword should be same password");
        }
        public void ApplyCustomValidationsRules()
        {

        }

    }
}
