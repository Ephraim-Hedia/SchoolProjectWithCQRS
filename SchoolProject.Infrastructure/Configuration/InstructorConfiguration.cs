using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configuration
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.InstructorId);

            builder.Property(i => i.InstructorNameAr)
                .HasMaxLength(200);

            builder.Property(i => i.InstructorNameEn)
                .HasMaxLength(200);

            builder.Property(i => i.Address)
                .HasMaxLength(200);

            builder.Property(i => i.Position)
                .HasMaxLength(100);

            builder.HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Supervisor)
                .WithMany(s => s.ManagedInstructors)
                .HasForeignKey(i => i.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(i => i.InstructorSubjects)
            .WithOne(Is => Is.Instructor)
            .HasForeignKey(Is => Is.InstructorId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.ManagedDepartment)
                .WithOne(d => d.InstructorDepartmentManager)
                .HasForeignKey<Department>(d => d.InstructorDepartmentManagerId)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
