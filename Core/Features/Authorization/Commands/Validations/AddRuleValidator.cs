using Core.Features.Authorization.Commands.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authorization.Commands.Validations
{
    public class AddRuleValidator :AbstractValidator<AddRulesCommand>
    {
        private readonly IAuthorizationService _authorizationService;
        public AddRuleValidator(IAuthorizationService authorizationService) 
        {
            _authorizationService = authorizationService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("IT Is Empty")
                .NotNull().WithMessage("Not Be Null");
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.RoleName).MustAsync(async (Key, CancellationToken) =>
            !await _authorizationService.IsRoleExist(Key))
                .WithMessage("this role name is exist");
        }

    }
}
