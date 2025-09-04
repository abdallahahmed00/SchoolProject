using Data.Entities;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Departmentcore.Queries.ResultDto
{
    public class GetDepartmentByIdResponse
    {
        public int DID { get; set; }
        public string Name { get; set;}
        public virtual ICollection<StudentRsponse>? StudentList { get; set; }
        public virtual ICollection<SubjectRsponse>? SubjectsList { get; set; }
        public virtual ICollection<InstrucortRsponse>? InstructorsList { get; set; }
        public string ManagerName { get; set; }
    }
    public class StudentRsponse
    {
        public int Id { get; set;  }
        public string Name { get; set; }
    }
    public class SubjectRsponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class InstrucortRsponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
