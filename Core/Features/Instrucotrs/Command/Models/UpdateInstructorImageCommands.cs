using Core.Basis;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Instrucotrs.Command.Models
{
    public class UpdateInstructorImageCommands :IRequest<Response<string>>
    {
        public int Id { get; set; }
        public IFormFile? Image { get; set; }

    }
}
