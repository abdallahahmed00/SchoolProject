using Core.Features.Departmentcore.Queries.Models;
using Core.Features.Instrucotrs.Queries.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;

namespace SchoolProject.Api.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InstructorController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public InstructorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetInstrucotrList()
        {
            var res = await _mediator.Send(new GetAllInstructorQuery());
            return NewResult(res);
        }


    }
    }
