using AutoMapper;
using Core.Basis;
using Core.Features.Instrucotrs.Command.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Data.Entities;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Instrucotrs.Command.Handlers
{
    public class InstructorCommandHandler :ResponseHandler,
        IRequestHandler<DeleteInstructorByIdCommand, Response<string>>,
        IRequestHandler<AddInstructorCommand, Response<string>>,
        IRequestHandler<UpdateInstructorImageCommands, Response<string>>
    {
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;
        public InstructorCommandHandler (IInstructorService instructorService, IMapper mapper)
        {
            _instructorService = instructorService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(DeleteInstructorByIdCommand request, CancellationToken cancellationToken)
        {
            var Instructor = await _instructorService.GetInstructorById(request.Id);
            if (Instructor == null)
            {
                return NotFound<string>("Id Not Found");
            }
            var result =await _instructorService.DeleteInstructor(Instructor);
            if (result =="Success")
            {
                return Deleted<string>("Instructor Deleted");
            }
            else
            {
             return BadRequest<string>("Deleted Failed");

            }
        }

        public async Task<Response<string>> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = _mapper.Map<Instructor>(request);
            var result = await _instructorService.AddInstructorAsync(instructor,request.Image);
            if(result!= "Success")
            {
                return BadRequest<string>("it failed");
            }
            return Success("Added");
        }

        public async Task<Response<string>> Handle(UpdateInstructorImageCommands request, CancellationToken cancellationToken)
        {
            var instructor = _mapper.Map<Instructor>(request);
            var result = await _instructorService.UpdateInstructorImageAsync(instructor.InsId, request.Image);

            if (result != "Success")
            {
                return BadRequest<string>("it failed");
            }
            return Success("Updated");
        }
    }
}
