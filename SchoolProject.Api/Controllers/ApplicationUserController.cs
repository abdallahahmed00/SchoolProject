using Core.Features.Students.Commands.Models;
using Core.Features.User.Commands.Models;
using Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ApplicationUserController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationUserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Router.ApplicationUserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand user)
        {
            var res = await _mediator.Send(user);
            return NewResult(res);
        }

    }
}
