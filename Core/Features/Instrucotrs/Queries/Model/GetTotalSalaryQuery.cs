using Core.Basis;
using Core.Features.Instrucotrs.Queries.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Instrucotrs.Queries.Model
{
    public class GetTotalSalaryQuery :IRequest <Response<GetTotalSalaryResponse>>
    {

    }
}
