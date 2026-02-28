using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Subject
    {
        public Subject()
        {
            StudentSubjects = new HashSet<StudentSubject>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
            InstructorSubjects = new HashSet<InstructorSubject>();
        }
        [Key]
        public int SubjectId { get; set; }
        [StringLength(200)]
        public string? SubjectName { get; set; }
        public DateTime? Period { get; set; }



        // RelationShip between Subject and Student as Subject
        [InverseProperty(nameof(StudentSubject.Subject))]
        public virtual ICollection<StudentSubject>? StudentSubjects { get; set; }


        // RelationShip between Subject and Department as Subject
        [InverseProperty(nameof(DepartmentSubject.Subject))]
        public virtual ICollection<DepartmentSubject>? DepartmentSubjects { get; set; }


        // RelationShip between Subject and Instructor as Subject

        [InverseProperty(nameof(InstructorSubject.Subject))]
        public virtual ICollection<InstructorSubject>? InstructorSubjects { get; set; }

    }
}
