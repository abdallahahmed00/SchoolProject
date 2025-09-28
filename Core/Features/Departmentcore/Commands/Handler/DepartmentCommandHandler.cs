using AutoMapper;
using Core.Basis;
using Core.Features.Departmentcore.Commands.models;
using Data.Entities;
using MediatR;
using Service.Abstract;
using Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Departmentcore.Commands.Handler
{
    public class DepartmentCommandHandler : ResponseHandler,
        IRequestHandler<AddDepartmentCommand, Response<string>>,
        IRequestHandler<UpdateSubjectInDepartmentCommand, Response<string>>,
        IRequestHandler<UpdateManagerDepartmentCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentSrvice _departmentSrvice;
        public DepartmentCommandHandler(IMapper mapper, IDepartmentSrvice departmentSrvice)
        {
            _departmentSrvice= departmentSrvice;
            _mapper = mapper;   
        }
        public async Task<Response<string>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            var depatmapper =  _mapper.Map<Department>(request);
            var result =await _departmentSrvice.AddDepartmentAsync(depatmapper);
            if (result== "Success")
            {
                return Success("Added Success");
            }

            else if (result== "It is Exist")
            {
              return BadRequest<string>("It Is Exist");

            }
            else return BadRequest<string>();


        }

        public async Task<Response<string>> Handle(UpdateSubjectInDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<Department>(request);

            var result = await _departmentSrvice.UpdateSubjectInDepartment(department);

            if (result == "Success")
            {
                return Success("Updated Successfully");
            }
            return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(UpdateManagerDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<Department>(request);

            var result = await _departmentSrvice.UpdateManagerDepartment(department);

            if (result == "Success")
            {
                return Success("Updated Successfully");
            }
            return BadRequest<string>(result);
        }
    }
}
