using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configuration
{
    public class InstructorSubjectConfiguration : IEntityTypeConfiguration<InstructorSubject>
    {
        public void Configure(EntityTypeBuilder<InstructorSubject> builder)
        {
            builder.HasKey(Is => new { Is.InstructorId, Is.SubjectId });

            builder.HasOne(Is => Is.Instructor)
                .WithMany(i => i.InstructorSubjects)
                .HasForeignKey(Is => Is.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(Is => Is.Subject)
                .WithMany(s => s.InstructorSubjects)
                .HasForeignKey(Is => Is.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
