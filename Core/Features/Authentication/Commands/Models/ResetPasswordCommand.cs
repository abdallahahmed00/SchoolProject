using Core.Basis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authentication.Commands.Models
{
    public class ResetPasswordCommand :IRequest<Response<string>>
    {
        public string Email { get; set; }
         

    }
}
