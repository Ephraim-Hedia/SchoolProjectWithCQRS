using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.DepeartmentId);

            builder.Property(d => d.DepartmentNameAr)
                .HasMaxLength(200);
            builder.Property(d => d.DepartmentNameEn)
                .HasMaxLength(200);

            builder.HasOne(d => d.InstructorDepartmentManager)
                .WithOne(i => i.ManagedDepartment)
                .HasForeignKey<Department>(d => d.InstructorDepartmentManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.Students)
            .WithOne(s => s.Department)
            .HasForeignKey(s => s.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.DepartmentSubjects)
                .WithOne(ds => ds.Department)
                .HasForeignKey(ds => ds.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(d => d.Instructors)
            .WithOne(i => i.Department)
            .HasForeignKey(i => i.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
