using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.DatabaseConntection;
using SchoolProject.Infrastructure.InfrastructureBases;
using SchoolProject.Infrastructure.Interfaces;

namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository :GenericRepository<Student>, IStudentRepository
    {

        #region Fields
        private readonly DbSet<Student> _students;
        #endregion

        #region Constructor
        public StudentRepository(ApplicationDbContext context ):base(context)
        {
            _students = context.Set<Student>();
            
        }
        #endregion


        #region Handles Functions
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _students.Include(s => s.Department).ToListAsync();
        }
        #endregion
    }
}
