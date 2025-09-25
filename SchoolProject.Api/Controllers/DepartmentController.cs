using Core.Features.Departmentcore.Queries.Models;
using Core.Features.Student.Queries.Models;
using Core.Features.Students.Queries.Models;
using Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using Serilog;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    [Authorize(Roles ="Admin,User")]
    public class DepartmentController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
       [AllowAnonymous]
        [HttpGet(Router.DepartmentRouting.List)]
        public async Task<IActionResult> GetDepartmentList()
        {
            var res = await _mediator.Send(new GetListDepartmentQuery());
            return NewResult(res);
        }
        [HttpGet(Router.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int Id)
        {
            var res = await _mediator.Send(new GetDepartmendByIdQuery(Id));
            return NewResult(res);
        }
        [HttpGet(Router.DepartmentRouting.TotalInstructor)]
        public async Task<IActionResult> TotalInstructor()
        {
            var res = await _mediator.Send(new GetTotalInstructorInDepartmentQuery());
            return NewResult(res);
        }
        [HttpGet(Router.DepartmentRouting.TotalStudent)]
        public async Task<IActionResult> TotalStudent()
        {
            var res = await _mediator.Send(new GetDepartmentStudentCountQuery());
            return NewResult(res);
        }
    }
}
