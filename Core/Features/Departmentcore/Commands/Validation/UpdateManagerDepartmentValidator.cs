using Core.Features.Departmentcore.Commands.models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Departmentcore.Commands.Validation
{
    internal class UpdateManagerDepartmentValidator : AbstractValidator<UpdateManagerDepartmentCommand>
    {
        public UpdateManagerDepartmentValidator()
        {
            ApplyValidator();
        }
        public void ApplyValidator()
        {
            RuleFor(x => x.DID).NotEmpty().WithMessage("DID is Empty").NotNull().WithMessage("DID Is Null");
        }
    
    }
}
