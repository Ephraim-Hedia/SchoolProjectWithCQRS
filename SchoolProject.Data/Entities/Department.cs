using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
            Instructors = new HashSet<Instructor>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepeartmentId { get; set; }
        [StringLength(200)]
        public string DepartmentName { get; set; }



        public int? InstructorDepartmentManagerId { get; set; }
        [ForeignKey(nameof(InstructorDepartmentManagerId))]
        [InverseProperty(nameof(Instructor.ManagedDepartment))]
        public virtual Instructor? InstructorDepartmentManager { get; set; }


        [InverseProperty(nameof(Student.Department))]
        public virtual ICollection<Student>? Students { get; set; }


        [InverseProperty(nameof(DepartmentSubject.Department))]
        public virtual ICollection<DepartmentSubject>? DepartmentSubjects { get; set; }


        [InverseProperty(nameof(Instructor.Department))]
        public virtual ICollection<Instructor>? Instructors { get; set; }

    }
}
