using Core.Basis;
using Core.Features.Students.Queries.ResultDto;
using MediatR;

namespace Core.Features.Students.Queries.Models
{
    public class GetStudentByNameQuery : IRequest<Response<GetSingleStudentResponse>>
    {
        public string Name { get; set; }

        public GetStudentByNameQuery(string name)
        {
            Name = name;
        }
    }
}
