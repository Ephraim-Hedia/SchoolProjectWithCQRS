using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Interfaces
{
    public interface IDepartmentService
    {
        public Task<string> CreateDepartmentAsync(Department department);
        public Task<string> EditDepartmentAsync(Department department);
        public Task<string> DeleteDepartmentAsync(int id);
        public Task<Department> GetDepartmentByIdAsync(int id);
        public Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        public Task<bool> IsNameExistAsync(string name);
        public Task<bool> IsDepartmentIdExistAsync(int id);
        public Task<bool> IsNameExistExcludeSelfAsync(string name, int id);
    }
}
