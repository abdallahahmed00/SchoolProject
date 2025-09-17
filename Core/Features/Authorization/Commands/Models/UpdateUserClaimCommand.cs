using Core.Basis;
using Data.Requests;
using Data.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authorization.Commands.Models
{
    public class UpdateUserClaimCommand : UpdateUserClaimRequest, IRequest<Response<string>>
    {

    }
}
