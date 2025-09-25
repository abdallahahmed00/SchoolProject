using Core.Basis;
using Data.Entities;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Departmentcore.Queries.ResultDto
{
    public class GetListDepartmentDto
    {
        public int DID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<StudentRsponse>? StudentList { get; set; }
        public virtual ICollection<SubjectRsponse>? SubjectsList { get; set; }
        public virtual ICollection<InstrucortRsponse>? InstructorsList { get; set; }
        public string ManagerName { get; set; }
    }
}
