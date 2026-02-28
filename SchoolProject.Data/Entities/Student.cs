using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Student
    {
        public Student()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int StudentId { get; set; }
        [StringLength(200)]
        public string? StudentName { get; set; }
        [StringLength(200)]
        public string? StudentAddress { get; set; }
        [StringLength(11)]
        public string? Phone { get; set; }

        public int? DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty(nameof(Department.Students))]
        public virtual Department? Department { get; set; }


        [InverseProperty(nameof(StudentSubject.Student))]
        public virtual ICollection<StudentSubject>? StudentSubjects { get; set; }
    }
}
