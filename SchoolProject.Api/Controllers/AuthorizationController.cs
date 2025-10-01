using Core.Features.Authorization.Commands.Models;
using Core.Features.Students.Commands.Models;
using Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using Data.AppMetaData;
using Core.Features.Authorization.Queries.Models;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class AuthorizationController : AppControllerBase
    {
        
        [HttpPost(Router.AuthorizationRouting.Create)]
        public async Task<IActionResult> Create([FromForm ] AddRulesCommand command)
        {
            var res = await _mediator.Send(command);
            return NewResult(res);
        }
        [HttpPost(Router.AuthorizationRouting.Edit)]
        public async Task<IActionResult> Edit([FromForm] EditRoleCommand command)
        {
            var res = await _mediator.Send(command);
            return NewResult(res);
        }
        [HttpDelete(Router.AuthorizationRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int Id )
        {
            var res = await _mediator.Send(new DeleteRuleCommand(Id));
            return NewResult(res);
        }
        [HttpGet(Router.AuthorizationRouting.GetList)]
        public async Task<IActionResult> GetList()
        {
            var res = await _mediator.Send(new GetRoleListQuery());
            return NewResult(res);
        }
        [HttpGet(Router.AuthorizationRouting.Get)]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var res = await _mediator.Send(new GetRoleByIdQuery(Id));
            return NewResult(res);
        }
        [HttpGet(Router.AuthorizationRouting.ManageUserRoles)]
        public async Task<IActionResult> ManageUserRoles([FromRoute] int Id)
        {
            var res = await _mediator.Send(new ManageUserRoleQuery(Id));
            return NewResult(res);
        }
        [HttpPost(Router.AuthorizationRouting.UpdateUserRoles)]
        public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserRolesCommand command)
        {
            var res = await _mediator.Send(command);
            return NewResult(res);
        }
        [HttpGet(Router.AuthorizationRouting.ManageUserClaim)]
        public async Task<IActionResult> ManageUserClaim([FromRoute] int Id)
        {
            var res = await _mediator.Send(new ManageUserClaimQuery(Id));
            return NewResult(res);
        }
        [HttpPost(Router.AuthorizationRouting.UpdateUserClaims)]
        public async Task<IActionResult> UpdateUserClaims([FromBody] UpdateUserClaimCommand command)
        {
            var res = await _mediator.Send(command);
            return NewResult(res);
        }
    }
}
