using Core.Features.Emails.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Emails.Commands.Validator
{
    public class SendEmailValidator :AbstractValidator<SendEmailCommand>
    {
        public SendEmailValidator() 
        {
            ApplyValidator();
        }
        public void ApplyValidator ()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is empty").
                NotNull().WithMessage("Email is null");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Message is empty").
             NotNull().WithMessage("Message is null");
        }
    }
}
