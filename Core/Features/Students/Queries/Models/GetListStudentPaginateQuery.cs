using MediatR;
using SchoolProject.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Queries.Models
{
    public class GetListStudentPaginateQuery :IRequest<PaginatedResult<GetListStudentPaginateQuery>>
    {
        public int PageNumber { get; set; }
        public int PageSizw { get; set; }
        public string []? OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
