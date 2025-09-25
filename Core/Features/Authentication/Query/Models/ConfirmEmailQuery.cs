using Core.Basis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authentication.Query.Models
{
    public class ConfirmEmailQuery :IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public string Code { get; set; }
    }
}
