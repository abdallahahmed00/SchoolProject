using Core.Basis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Instrucotrs.Command.Models
{
    public class DeleteInstructorByIdCommand :IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteInstructorByIdCommand(int id)
        {
            Id = id;
        }
    }
}
