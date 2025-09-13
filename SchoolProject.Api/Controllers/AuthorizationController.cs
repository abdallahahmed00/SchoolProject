using Core.Features.Authorization.Commands.Models;
using Core.Features.Students.Commands.Models;
using Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class AuthorizationController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorizationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Router.AuthorizationRouting.Create)]
        public async Task<IActionResult> Create([FromForm ] AddRulesCommand command)
        {
            var res = await _mediator.Send(command);
            return NewResult(res);
        }

    }
}
