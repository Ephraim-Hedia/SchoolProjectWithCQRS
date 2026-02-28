using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.DatabaseConntection
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorSubject> InstructorSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSubject>()
                .HasKey(ss => new { ss.StudentId, ss.SubjectId });
            modelBuilder.Entity<DepartmentSubject>()
                .HasKey(ds => new { ds.DepartmentId, ds.SubjectId });
            modelBuilder.Entity<InstructorSubject>()
                .HasKey(Is => new { Is.InstructorId, Is.SubjectId });


            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.StudentId);


            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Supervisor)
                .WithMany(s => s.ManagedInstructors)
                .HasForeignKey(i => i.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.ManagedDepartment)
                .WithOne(d => d.InstructorDepartmentManager)
                .HasForeignKey<Instructor>(i => i.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InstructorSubject>()
                .HasOne(Is => Is.Instructor)
                .WithMany(i => i.InstructorSubjects)
                .HasForeignKey(Is => Is.InstructorId);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.SubjectId);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Instructors)
                .WithOne(i => i.Department)
                .HasForeignKey(i => i.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.DepartmentSubjects)
                .WithOne(ds => ds.Department)
                .HasForeignKey(ds => ds.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.InstructorDepartmentManager)
                .WithOne(i => i.ManagedDepartment)
                .HasForeignKey<Instructor>(i => i.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.ManagedDepartment)
                .WithOne(d => d.InstructorDepartmentManager)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
