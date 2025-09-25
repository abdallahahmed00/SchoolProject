using Core.Basis;
using Core.Features.Emails.Commands.Models;
using MediatR;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Emails.Commands.Handler
{
    public class EmailsCommandHandler :ResponseHandler,
        IRequestHandler<SendEmailCommand,Response<string>>
    {
        private readonly IEmailService _emailservice;
        public EmailsCommandHandler(IEmailService emailservice)
        {
            _emailservice = emailservice;
        }

        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var response = await _emailservice.SendEmail(request.Email, request.Message,null);
            if(response=="Success")
            {
                return Success(response); 
            }
            return BadRequest<string>();
        }
    }
}
