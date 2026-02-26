using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        public Task<IEnumerable<Student>> GetAllStudentsAsync();
    }
}
