using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);
            builder.Property(s => s.StudentName)
              .IsRequired()
              .HasMaxLength(200);

            builder.Property(s => s.StudentAddress)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(s => s.Phone)
                .IsRequired()
                .HasMaxLength(11);

            builder.HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.StudentSubjects)
                .WithOne(ss => ss.Student)
                .HasForeignKey(ss => ss.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
