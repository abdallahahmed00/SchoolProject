using AutoMapper;
using Core.Basis;
using Core.Features.Instrucotrs.Queries.Model;
using Core.Features.Instrucotrs.Queries.Result;
using MediatR;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Basis;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace Core.Features.Instrucotrs.Queries.Handler
{
    public class InstructorQueryHandler :ResponseHandler , 
        IRequestHandler<GetAllInstructorQuery, Response<List<GetAllInstrucorResponse>>>,
        IRequestHandler<GetInstructorByIdQuery, Response<GetInstructorByIdResponse>>,
        IRequestHandler<GetTotalSalaryQuery, Response<GetTotalSalaryResponse>>
    {
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper; 
        public InstructorQueryHandler(IInstructorService instructorService, IMapper mapper)
        {
            _instructorService = instructorService;
            _mapper = mapper;
        }

        public async Task<Response<List<GetAllInstrucorResponse>>> Handle(GetAllInstructorQuery request, CancellationToken cancellationToken)
        {
           var instrucotr=  await _instructorService.GetAllInstructor();
            var mapper = _mapper.Map<List<GetAllInstrucorResponse>>(instrucotr);
              return Success(mapper);
        }

        public async Task<Response<GetInstructorByIdResponse>> Handle(GetInstructorByIdQuery request, CancellationToken cancellationToken)
        {
            var instructor = await _instructorService.GetInstructorById(request.Id);
            var instructormapper = _mapper.Map<GetInstructorByIdResponse>(instructor);
            return Success(instructormapper);
        }

        public async Task<Response<GetTotalSalaryResponse>> Handle(GetTotalSalaryQuery request, CancellationToken cancellationToken)
        {
            var salary =await _instructorService.GetTotalSalary();
                var result = new GetTotalSalaryResponse { Salary = salary };
            return Success (result);
        }
    }
}
