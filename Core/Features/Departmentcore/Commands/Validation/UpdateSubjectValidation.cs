using Core.Features.Departmentcore.Commands.models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Departmentcore.Commands.Validation
{
    public class UpdateSubjectValidation : AbstractValidator<UpdateSubjectInDepartmentCommand>
    {
        public UpdateSubjectValidation()
        {
            ApplyValidator();
        }
        public void ApplyValidator()
        {
            RuleFor(x => x.DID).NotEmpty().WithMessage("id is Empty").NotNull().WithMessage("id Is Null");
            RuleFor(x => x.SubjectsId).NotEmpty().WithMessage("SubjectsId is Empty")
                .NotNull().WithMessage("SubjectsId Is Null");
        }
    }
}
