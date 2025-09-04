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
        public int? InsManager { get; set; }
        public virtual ICollection<Data.Entities.Student> StudentList { get; set; }
        public virtual ICollection<DepartmetSubject> DepartmentSubjectsList { get; set; }
        public virtual ICollection<Instructor> InstructorsList { get; set; }
        public virtual Instructor? Instructor { get; set; }
    }
}
