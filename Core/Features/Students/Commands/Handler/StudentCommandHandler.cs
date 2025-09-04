using AutoMapper;
using Core.Basis;
using Core.Features.Students.Commands.Models;
using Data.Entities;
using infrastructure.Interface;
using MediatR;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
namespace Core.Features.Students.Commands.Handler
{
    public class StudentCommandHandler:ResponseHandler,
                                IRequestHandler<AddStudentCommand,Response<string>> ,
                                IRequestHandler<EditStudentCommand,Response<string>> ,
                                IRequestHandler<DeleteStudentCommand,Response<string>> ,
                                IRequestHandler<EditNameStudentCommand,Response<string>> 
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentCommandHandler(IStudentService studentService , IMapper mapper) 
        {
        _studentService = studentService;   
            _mapper = mapper;   
        }

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentmapper = _mapper.Map<Data.Entities.Student>(request);

            var result =await _studentService.AddStudentAsync(studentmapper);

           
             if (result == "Success")
            {
                return Success("Added Success");
            }
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {

            var student =await _studentService.GetStudentByIdWithIncludeAsync(request.Id); 
             if(student==null)
            {
                return NotFound<string>("Name not found ");
            }
            var studentmapper = _mapper.Map<Data.Entities.Student>(request);
            var result =await _studentService.EditStudentAsync(studentmapper);

            if (result == "Success")
            {
                return Created("Edit Success");
            }
            else return BadRequest<string>();
        


    }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
            
        {
            var student = await _studentService.GetByIdAsync(request.Id);
            if (student == null)
            {
                return NotFound<string>("Name not found ");
            }
             var result =await _studentService.DeleteStudentAsync(student);

            if (result == "Success")
            {
                return Deleted<string>("Deleted Success");
            }
            else return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(EditNameStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetByIdAsync(request.Id);
            if (student == null)
            {
                return NotFound<string>("Name not found ");
            }
            if (student.Name.Equals(request.Name,StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest<string>("The new name is the same as the current name.");
            }
            student.Name = request.Name;
            var result = await _studentService.EditStudentAsync(student);


            if (result == "Success")
            {
                return Created("Edit Success");
            }
            else return BadRequest<string>();

        }
    }
}
