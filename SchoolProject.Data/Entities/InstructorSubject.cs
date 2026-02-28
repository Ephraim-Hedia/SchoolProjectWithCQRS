using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class InstructorSubject
    {
        [Key]
        public int InstructorId { get; set; }
        [Key]
        public int SubjectId { get; set; }


        [ForeignKey(nameof(InstructorId))]
        [InverseProperty(nameof(Instructor.InstructorSubjects))]
        public Instructor? Instructor { get; set; }


        [ForeignKey(nameof(SubjectId))]
        [InverseProperty(nameof(Subject.InstructorSubjects))]
        public Subject? Subject { get; set; }
    }
}
