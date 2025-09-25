using Core.Features.Departmentcore.Queries.Models;
using Core.Features.Instrucotrs.Command.Models;
using Core.Features.Instrucotrs.Queries.Model;
using Core.Features.Students.Commands.Models;
using Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;

namespace SchoolProject.Api.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class InstructorController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public InstructorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Router.InstructorRouting.List)]
        public async Task<IActionResult> GetInstrucotrList()
        {
            var res = await _mediator.Send(new GetAllInstructorQuery());
            return NewResult(res);
        }

        [HttpGet(Router.InstructorRouting.GetById)]

        public async Task<IActionResult> GetInstructorById([FromRoute] int Id)
        {
            var res = await _mediator.Send(new GetInstructorByIdQuery(Id));
            return NewResult(res);
        }
        [HttpDelete(Router.InstructorRouting.Delete)]
        public async Task<IActionResult> Delete(int Id)
        {
            var res = await _mediator.Send(new DeleteInstructorByIdCommand(Id));
            return NewResult(res);
        }
        [HttpGet(Router.InstructorRouting.TotalSalary)]
        public async Task<IActionResult> GetTotalSalary()
        {
            var res = await _mediator.Send(new GetTotalSalaryQuery());
            return NewResult(res);
        }
        [HttpPost(Router.InstructorRouting.AddInstructor)]
        public async Task<IActionResult> AddInstructor([FromForm] AddInstructorCommand command)
        {
            var res = await _mediator.Send(command);
            return NewResult(res);
        }
        [HttpPost(Router.InstructorRouting.UpdateImageInstructor)]
        public async Task<IActionResult> UpdateImageInstructor([FromForm] UpdateInstructorImageCommands command)
        {
            var res = await _mediator.Send(command);
            return NewResult(res);
        }

    }
}
