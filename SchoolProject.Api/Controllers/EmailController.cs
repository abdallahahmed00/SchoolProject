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
        
        [HttpPost(Router.EmailRouting.SendEmail)]
        public async Task<IActionResult> SendEmail([FromBody] SendEmailCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            var res = await _mediator.Send(command);
            return NewResult(res); 
        }

    }
}
