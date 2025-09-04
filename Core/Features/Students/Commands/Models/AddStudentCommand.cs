using Core.Basis;
using Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Commands.Models
{
    public class AddStudentCommand :IRequest<Response<string>>
    {
        [Required]
        [MaxLength(20,ErrorMessage ="Must Be Lower than 20")]
        [NotNull]
        public string Name { get; set; }
        public string Address { get; set; }
        [MaxLength(11)]
        [MinLength(11)]
        public string Phone { get; set; }
        [Required(ErrorMessage ="You must enter DID")]
        public int DepartmentId { get; set; }

    }
}
