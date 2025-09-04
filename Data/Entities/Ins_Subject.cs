using Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Ins_Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int InsSub { get; set; }
        public int InsId { get; set; }
        
        public int SubId { get; set; }
        [ForeignKey(nameof(InsId))]
        [InverseProperty("Ins_Subjects")]
        public Instructor? instructor { get; set; }
        [ForeignKey(nameof(SubId))]
        [InverseProperty("Ins_Subjects")]
        public Subjects? Subject { get; set; }

    }
}