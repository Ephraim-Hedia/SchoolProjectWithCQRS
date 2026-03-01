using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Interfaces;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {

        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        #endregion

        #region Constructors
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion

        #region Handle Functions

        public Task<string> CreateDepartmentAsync(Department department)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteDepartmentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditDepartmentAsync(Department department)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.GetTableNoTracking()
                 .Where(department => department.DepeartmentId == id)
                 .Include(Department => Department.Students)
                 .Include(Department => Department.DepartmentSubjects).ThenInclude(DepartmentSubject => DepartmentSubject.Subject)
                 .Include(Department => Department.Instructors)
                 .Include(Department => Department.InstructorDepartmentManager)
                 .FirstOrDefaultAsync();

            return department;
        }

        public Task<bool> IsDepartmentIdExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsNameExistAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsNameExistExcludeSelfAsync(string name, int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
