using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.DatabaseConntection;
using SchoolProject.Infrastructure.InfrastructureBases;
using SchoolProject.Infrastructure.Interfaces;

namespace SchoolProject.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        #region Fields
        private readonly DbSet<Department> _departments;
        #endregion

        #region Constructors
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _departments = dbContext.Set<Department>();
        }
        #endregion

        #region Handler Functions

        #endregion
    }
}
