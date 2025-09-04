using Core.Features.Departmentcore.Queries.Models;
using Core.Features.Student.Queries.Models;
using Core.Features.Students.Queries.Models;
using Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;

namespace SchoolProject.Api.Controllers
{
    //   [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
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
    }
}
