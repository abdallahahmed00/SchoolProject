using Core.Basis;
using Core.Features.Students.Queries.ResultDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Queries.Models
{
    public class GetStuentByFilterQuery :IRequest<Response<List<GetStudentByFilterResult>>>
    {
        public int? StudID { get; set; }
        public string? Name { get; set; }
        public int? DID { get; set; }

        public decimal? Grade { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }


    }
}
