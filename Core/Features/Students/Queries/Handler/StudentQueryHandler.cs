using AutoMapper;
using Core.Basis;
using Core.Features.Student.Queries.Models;
using Core.Features.Students.Queries.Models;
using Core.Features.Students.Queries.ResultDto;
using Data.Entities;
using MediatR;
using SchoolProject.Core.Wrappers;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Queries.Handler
{
    public class StudentQueryHandler : ResponseHandler,
    IRequestHandler<GetListStudentQuery, Response<List<GetListStudentDto>>>,
    IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>,
    IRequestHandler<GetStudentByNameQuery, Response<GetSingleStudentResponse>>,
    IRequestHandler<GetStuentByFilterQuery, Response<List<GetStudentByFilterResult>>>

    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper; 

        public StudentQueryHandler(IStudentService studentService, IMapper mapper) 
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<Response<List<GetListStudentDto>>> Handle(GetListStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentListAsync();
            var studentMapper = _mapper.Map<List<GetListStudentDto>>(student);
            return Success( studentMapper);
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdWithIncludeAsync(request.Id);
            if (student ==null)
            {
                return NotFound<GetSingleStudentResponse>($"Not Found Student {request.Id}");
            }
            var result = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(result);
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByNameQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByNameAsync(request.Name);
            if (student == null)
            {
                return NotFound<GetSingleStudentResponse>($"Not Found Student {request.Name}");
            }
            var result = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(result);


        }

            public async Task<Response<List<GetStudentByFilterResult>>>Handle(GetStuentByFilterQuery request, CancellationToken cancellationToken)
            {
            var students = await _studentService.FilterStudentsAsync( request.Grade, request.Name,
                                                 request.Address, request.Phone
                                                 ,request.DID,request.StudID);

            if (students == null || !students.Any())
            {
                return BadRequest<List<GetStudentByFilterResult>>("Cant find");
            }

            var result = _mapper.Map<List<GetStudentByFilterResult>>(students);
            return Success(result); 
        }
    }
}
