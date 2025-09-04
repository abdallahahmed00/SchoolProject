using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class StudentSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int StudSubID { get; set; }
        public int StudID { get; set; }
        public int SubID { get; set; }
        public decimal? grade { get; set; }
    

        [ForeignKey("StudID")]
        [InverseProperty("StudentSubject")]
        public virtual Student Student { get; set; }

        [ForeignKey("SubID")]
        [InverseProperty("StudentsSubjects")]
        public virtual Subjects Subject { get; set; }

    }
}
