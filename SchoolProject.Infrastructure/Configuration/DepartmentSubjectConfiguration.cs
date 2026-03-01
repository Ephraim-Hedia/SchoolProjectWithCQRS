using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configuration
{
    public class DepartmentSubjectConfiguration : IEntityTypeConfiguration<DepartmentSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
        {
            builder.HasKey(ds => new { ds.SubjectId, ds.DepartmentId });

            builder.HasOne(ds => ds.Department)
                .WithMany(d => d.DepartmentSubjects)
                .HasForeignKey(ds => ds.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ds => ds.Subject)
                .WithMany(s => s.DepartmentSubjects)
                .HasForeignKey(ds => ds.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
