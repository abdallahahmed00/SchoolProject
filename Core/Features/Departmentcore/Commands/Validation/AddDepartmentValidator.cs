using Core.Features.Departmentcore.Commands.models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Departmentcore.Commands.Validation
{
    public class AddDepartmentValidator :AbstractValidator<AddDepartmentCommand>
    {
        public AddDepartmentValidator() 
        {
            ApplyValidator();
        }
        public void ApplyValidator()
        {
            RuleFor(x => x.DName).NotEmpty().WithMessage("Name is Empty").NotNull().WithMessage("Name Is Null");
        }
    }
}
