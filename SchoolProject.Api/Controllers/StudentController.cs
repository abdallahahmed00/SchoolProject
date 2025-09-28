using Core.Features.Student.Queries.Models;
using Core.Features.Students.Commands.Models;
using Core.Features.Students.Queries.Models;
using Core.Features.Students.Queries.ResultDto;
using Data.AppMetaData;
using Data.Entities;
using Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class StudentController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles="User")]
        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var res = await _mediator.Send(new GetListStudentQuery());
            return NewResult(res);
        }
        [SwaggerOperation(Summary ="Get Student By id",OperationId = "GetById")]
        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int Id)
        {
            var res = await _mediator.Send(new GetStudentByIdQuery(Id));
            return NewResult(res);
        }
        [HttpGet(Router.StudentRouting.GetByName)]
        public async Task<IActionResult> GetStudentByName([FromRoute] string Name)
        {
            var res = await _mediator.Send(new GetStudentByNameQuery(Name));
            return NewResult(res);
        }

        [HttpPost(Router.StudentRouting.create)]
        public async Task<IActionResult> Create([FromBody] AddStudentCommand student)
        {
            var res = await _mediator.Send(student);
            return NewResult(res);
        }


        [HttpPut(Router.StudentRouting.Update)]
        public async Task<IActionResult> Update([FromBody] EditStudentCommand student)
        {
            var res = await _mediator.Send(student);
            return NewResult(res);
        }
        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> Delete(int Id)
        {
            var res = await _mediator.Send(new DeleteStudentCommand(Id));
            return NewResult(res);
        }

        [HttpPut(Router.StudentRouting.UpdateName)]
        public async Task<IActionResult> UpdateName([FromBody] EditNameStudentCommand student)
        {
            var res = await _mediator.Send(student);
            return NewResult(res);
        }

    }
}

