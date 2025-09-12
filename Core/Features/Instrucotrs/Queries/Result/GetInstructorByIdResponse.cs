using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Instrucotrs.Queries.Result
{
    public class GetInstructorByIdResponse
    {
        public int InsId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public DepartmentResponse? Department { get; set; }
        public List<InsSub>? Subjects { get; set; }
    }
    

}
