using Core.Basis;
using Core.Features.Students.Queries.ResultDto;
using Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<GetSingleStudentResponse>>
    {
       
        public int Id { get; set; }
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
