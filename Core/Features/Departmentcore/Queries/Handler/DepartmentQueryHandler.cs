using AutoMapper;
using Core.Basis;
using Core.Features.Departmentcore.Queries.Models;
using Core.Features.Departmentcore.Queries.ResultDto;
using MediatR;
using Service.Abstract;

namespace Core.Features.Departmentcore.Queries.Handler
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetListDepartmentQuery, Response<List<GetListDepartmentDto>>>,
IRequestHandler<GetDepartmendByIdQuery, Response<GetDepartmentByIdResponse>>,
IRequestHandler<GetTotalInstructorInDepartmentQuery, Response<List< GetTotalInstructorInDepartmentResponse>>>,
IRequestHandler<GetDepartmentStudentCountQuery, Response<List< GetDepartmentStudentCountResult>>>
    {
        private readonly IDepartmentSrvice _departmentservice;
        private readonly IMapper _mapper;

        public DepartmentQueryHandler(IDepartmentSrvice dept, IMapper mapper)
        {
            _departmentservice = dept;
            _mapper = mapper;
        }

        public async Task<Response<List<GetListDepartmentDto>>> Handle(GetListDepartmentQuery request, CancellationToken cancellationToken)
        {
            var departments = await _departmentservice.GetAllDepartment();

            var result = _mapper.Map<List<GetListDepartmentDto>>(departments);

            return Success(result);
        }

        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmendByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentservice.GetDepartmentByIdAsync(request.Id);
            if (department==null)
            {
                return NotFound<GetDepartmentByIdResponse>("Not found this id");
            }
            var mapper = _mapper.Map<GetDepartmentByIdResponse>(department);
            return Success(mapper); 
        }

        public async Task<Response<List<GetTotalInstructorInDepartmentResponse>>> Handle(GetTotalInstructorInDepartmentQuery request, CancellationToken cancellationToken)
        {
            var departments = await _departmentservice.GetNumberOfInstructorinDepartment();

            var result = _mapper.Map<List<GetTotalInstructorInDepartmentResponse>>(departments);

            return Success(result);
        }

        public async Task<Response<List<GetDepartmentStudentCountResult>>> Handle(GetDepartmentStudentCountQuery request, CancellationToken cancellationToken)
        {
            var viewdata =await _departmentservice.GetCountStudentInDepartmentAsync();
            var mapper = _mapper.Map<List<GetDepartmentStudentCountResult>>(viewdata);
            return Success(mapper);
        }
    }
}
