using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Instructor
    {
        public Instructor()
        {
            ManagedInstructors = new HashSet<Instructor>();
            InstructorSubjects = new HashSet<InstructorSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstructorId { get; set; }
        public string? InstructorNameAr { get; set; }
        public string? InstructorNameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public string? Image { get; set; }

        // RelationShip between Instructor and Department as Employee
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty(nameof(Department.Instructors))]
        public Department? Department { get; set; }

        // RelationShip between Instructor and Department as Manager
        [InverseProperty(nameof(Department.InstructorDepartmentManager))]
        public Department? ManagedDepartment { get; set; }


        // RelationShip between Instructor and Instructor as Supervisor
        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty("ManagedInstructors")]
        public Instructor? Supervisor { get; set; }
        [InverseProperty("Supervisor")]
        public virtual ICollection<Instructor> ManagedInstructors { get; set; }


        // RelationShip between Instructor and Subject as Instructor
        [InverseProperty(nameof(InstructorSubject.Instructor))]
        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; }
    }
}
