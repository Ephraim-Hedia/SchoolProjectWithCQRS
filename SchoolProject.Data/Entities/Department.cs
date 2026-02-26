using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities
{
    public class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
        }
        [Key]
        public int DepeartmentId { get; set; }
        [StringLength(200)]
        public string DepartmentName { get; set; } 

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }

    }
}
