using Core.Features.Instrucotrs.Command.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Instrucotrs.Command.Validation
{
    public class AddInstructorValidator :AbstractValidator<AddInstructorCommand>
    {
        private readonly IDepartmentSrvice _departmentSrvice;
        private readonly IInstructorService _instructorservice;
        public AddInstructorValidator(IDepartmentSrvice departmentSrvice, IInstructorService instructorservice) 
        {
        _departmentSrvice=departmentSrvice;
            _instructorservice = instructorservice;
            ApplyValidationRule();
            ApplyCustomValidationRules();
        }
        public void ApplyValidationRule()
        {
            RuleFor(x => x.DID).NotEmpty().WithMessage("DIDIsEmpty")
                .NotNull().WithMessage("DIIsNull");
            RuleFor(x => x.Name).NotEmpty().WithMessage("NameIsEmpty")
                .NotNull().WithMessage("NameIsNull");
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.DID).MustAsync(async (Key, CancellationToken) => await _departmentSrvice.IsDepartmentExist(Key))
                .WithMessage("This department must be exist");
            RuleFor(x => x.Name).MustAsync(async (Key, CancellationToken) => await _instructorservice.IsNameExist(Key))
               .WithMessage("This Instructor is exist");
        }
    }
}
