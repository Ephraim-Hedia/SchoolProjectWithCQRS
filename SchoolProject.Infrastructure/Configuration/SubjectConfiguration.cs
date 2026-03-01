using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configuration
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(s => s.SubjectId);
            builder.Property(s => s.SubjectNameAr)
                .HasMaxLength(200);
            builder.Property(s => s.SubjectNameEn)
                .HasMaxLength(200);

            //builder.Property(s => s.Period)
            //    .HasColumnType("datetime");


            builder.HasMany(s => s.StudentSubjects)
                .WithOne(ss => ss.Subject)
                .HasForeignKey(ss => ss.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.DepartmentSubjects)
                .WithOne(ds => ds.Subject)
                .HasForeignKey(ds => ds.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.InstructorSubjects)
                .WithOne(Is => Is.Subject)
                .HasForeignKey(Is => Is.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
