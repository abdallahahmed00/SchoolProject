using Core.Features.Instrucotrs.Command.Models;
using FluentValidation;
using Service.Abstract;
using Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Instrucotrs.Command.Validation
{
    public class UpdateInstructorImageValidator :AbstractValidator<UpdateInstructorImageCommands>
    {
        private readonly IInstructorService _instructorService;
        public UpdateInstructorImageValidator(IInstructorService instructorService) 
        {
            _instructorService = instructorService;
            ApplyValidationRule();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRule()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Empty").NotNull().WithMessage("Id is NULL");
        }
        public void ApplyCustomValidationRules()
        {

            RuleFor(x => x.Id).MustAsync(async (Key, CancellationToken)
                => await _instructorService.IsNameExistById(Key))
                         .WithMessage("This Instructor is exist");
        }
    }
}
