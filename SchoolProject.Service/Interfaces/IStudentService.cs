using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.Interfaces
{
    public interface IStudentService
    {
        public Task<IEnumerable<Student>> GetAllStudentsAsync();
        public Task<Student> GetStudentByIdAsync(int id);

        public Task<string> CreateStudentAsync(Student student);

        public Task<bool> IsNameExistAsync(string name);
        public Task<bool> IsStudentIdExistAsync(int id);
        public Task<string> EditStudentAsync(Student student);
        public Task<bool> IsNameExistExcludeSelfAsync(string name, int id);
        public Task<string> DeleteStudentAsync(int id);
        public IQueryable<Student> GetStudentsQuerable();
        public IQueryable<Student> FilterStudentsPaginatedQuerable(StudentOrderingEnum? orderBy, string? search);

    }
}
