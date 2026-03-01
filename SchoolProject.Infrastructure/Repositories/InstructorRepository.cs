using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.DatabaseConntection;
using SchoolProject.Infrastructure.InfrastructureBases;
using SchoolProject.Infrastructure.Interfaces;

namespace SchoolProject.Infrastructure.Repositories
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        #region Fields
        private readonly DbSet<Instructor> _instructors;
        #endregion

        #region Constructors
        public InstructorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _instructors = dbContext.Set<Instructor>();
        }
        #endregion
        #region Handle Functions

        #endregion
    }
}
