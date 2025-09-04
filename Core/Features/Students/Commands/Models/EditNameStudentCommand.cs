using Core.Basis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Commands.Models
{
    public class EditNameStudentCommand :IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
