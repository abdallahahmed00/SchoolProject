using Core.Features.Emails.Commands.Models;
using Core.Features.User.Commands.Models;
using Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class EmailController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public EmailController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Router.EmailRouting.SendEmail)]
        public async Task<IActionResult> SendEmail([FromBody] SendEmailCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // هيساعدك تعرف فين الغلط لو البايندنج فشل

            var res = await _mediator.Send(command);
            return NewResult(res); 
        }

    }
}
