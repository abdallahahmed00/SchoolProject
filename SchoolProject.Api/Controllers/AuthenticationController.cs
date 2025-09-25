using Core.Features.Authentication.Commands.Models;
using Core.Features.Authentication.Query.Models;
using Core.Features.User.Queries.Models;
using Data.AppMetaData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class AuthenticationController : AppControllerBase

    {
        [HttpPost(Router.AuthenticationRouting.SighIn)]
        public async Task<IActionResult> GetUser([FromForm] SignInCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }
        [HttpPost(Router.AuthenticationRouting.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }
        [HttpGet(Router.AuthenticationRouting.ValidateToken)]
        public async Task<IActionResult> ValidateToken([FromQuery] AuthorizeUserQuery command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }
        [HttpGet(Router.AuthenticationRouting.ConfirmEmail)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok(res);
        }
        [HttpPost(Router.AuthenticationRouting.SendResetPassword)]
        public async Task<IActionResult> SendResetPassword([FromQuery] ResetPasswordCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }
        [HttpGet(Router.AuthenticationRouting.ConfirmResetPassword)]
        public async Task<IActionResult> ConfirmResetPassword([FromQuery] ConfirmResetPasswordQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok(res);
        }
        [HttpPost(Router.AuthenticationRouting.ResetPassword)]
        public async Task<IActionResult> ResetPassword([FromQuery] SetNewPasswordCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
} 
