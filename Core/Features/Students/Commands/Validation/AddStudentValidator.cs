using Core.Features.Students.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Commands.Validation
{
    public class AddStudentValidator:AbstractValidator <AddStudentCommand>
    {

        public AddStudentValidator() 
        {
            ApplyValidationRules();


        }
       public void ApplyValidationRules()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Must Not Be Empty")
              .NotNull().
                MaximumLength(20);
        }
    }
}
