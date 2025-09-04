using Core.Basis;
using Core.Features.Departmentcore.Queries.ResultDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Departmentcore.Queries.Models
{
    public class GetListDepartmentQuery :IRequest<Response<List<GetListDepartmentDto>>>
    {

    }
}
