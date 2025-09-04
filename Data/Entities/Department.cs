using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
//Add - Migration AddEntity - Project Infrastructure - StartupProject SchoolProject.Api
namespace Data.Entities
{
    public partial class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int DID { get; set; }
        [StringLength(500)]
        public string DName { get; set; } 
        [InverseProperty("Department")]
        public virtual ICollection<Student> Students { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }

        public int? InsManager { get; set; }
        [ForeignKey("InsManager")]
        [InverseProperty("departmentManager")]
        public virtual Instructor Instructor { get; set; }
        [InverseProperty("department")]
        public virtual ICollection<Instructor> Instructors { get; set; }

    }

}
