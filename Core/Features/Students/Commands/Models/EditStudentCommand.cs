using Core.Basis;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Commands.Models
{
        public class EditStudentCommand :IRequest<Response<string>>
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public int DepartmentId { get; set; }
        }
    }
