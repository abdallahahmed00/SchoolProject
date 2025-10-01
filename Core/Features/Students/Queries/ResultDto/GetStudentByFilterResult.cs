using Core.Features.Departmentcore.Queries.ResultDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Queries.ResultDto
{
    public class GetStudentByFilterResult
    {
        public int StudID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<SubStdResponse>? SubjectList { get; set; }

    }
    public class SubStdResponse
    {
      public  string Name { get; set;}
        public decimal Grade { get; set;}

    }

}
