using Core.Features.Student.Queries.Models;
using Core.Features.Students.Commands.Models;
using Core.Features.User.Commands.Models;
using Core.Features.User.Queries.Models;
using Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;

namespace SchoolProject.Api.Controllers
{
  //  [Route("api/[controller]")]
    [ApiController]

    public class ApplicationUserController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationUserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Router.ApplicationUserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand coomand)
        {
            var res = await _mediator.Send(coomand);
            return NewResult(res);
        }

        [HttpGet(Router.ApplicationUserRouting.GetAll)]
        public async Task<IActionResult> GetUser([FromQuery] GetListUserQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok (res);
        }
        [HttpGet(Router.ApplicationUserRouting.GetById)]
        public async Task<IActionResult> GetUserByid([FromRoute] int id)
        {
            var res = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(res);
        }

        [HttpPut(Router.ApplicationUserRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            var res = await _mediator.Send(command);
            return NewResult(res);
        }
        [HttpDelete(Router.ApplicationUserRouting.Delete)]
        public async Task<IActionResult> Delete(int Id)
        {
            var res = await _mediator.Send(new DeleteUserCommand(Id));
            return NewResult(res);
        }

        [HttpPut(Router.ApplicationUserRouting.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {
            var res = await _mediator.Send(command);
            return NewResult(res);
        }
    }
}
