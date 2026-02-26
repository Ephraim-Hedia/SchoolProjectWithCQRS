using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [StringLength(200)]
        public string StudentName { get; set; }
        [StringLength(200)]
        public string StudentAddress { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }

        public int? DepartmentId { get; set; }
         
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}
