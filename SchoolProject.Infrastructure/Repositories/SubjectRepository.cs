using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.DatabaseConntection;
using SchoolProject.Infrastructure.InfrastructureBases;
using SchoolProject.Infrastructure.Interfaces;

namespace SchoolProject.Infrastructure.Repositories
{
    internal class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        #region Fields
        private readonly DbSet<Subject> _subjects;
        #endregion
        #region Constructors
        public SubjectRepository(ApplicationDbContext context) : base(context)
        {
            _subjects = context.Set<Subject>();
        }
        #endregion
        #region Handle Functions
        #endregion
    }
}
