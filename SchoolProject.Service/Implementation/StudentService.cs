using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;
using SchoolProject.Infrastructure.Interfaces;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Service.Implementation
{
    public class StudentService : IStudentService
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region Constructor
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        #endregion

        #region Handles Functions
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            //return await _studentRepository.GetByIdAsync(id);
            return await _studentRepository.GetTableNoTracking()
                    .Include(s => s.Department)
                    .FirstOrDefaultAsync(s => s.StudentId == id);
        }
        public async Task<string> CreateStudentAsync(Student student)
        {
            await _studentRepository.AddAsync(student);
            return "Student Created Successfully";
        }

        public async Task<bool> IsNameExistAsync(string name)
        {
            // check if the student name is exist or not 
            var studentNameExist = await _studentRepository.GetTableNoTracking()
                .AnyAsync(s => s.StudentName == name);
            if (!studentNameExist)
                return false;

            return true;
        }

        public async Task<string> EditStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Student Updated Successfully";
        }

        public async Task<bool> IsNameExistExcludeSelfAsync(string name, int id)
        {
            // check if the student name is exist or not 
            var studentNameExist = await _studentRepository.GetTableNoTracking()
                .AnyAsync(s => s.StudentName == name && s.StudentId != id);
            if (!studentNameExist)
                return false;

            return true;
        }

        public async Task<bool> IsStudentIdExistAsync(int id)
        {
            var studentIdExist = await _studentRepository.GetTableNoTracking()
                .AnyAsync(s => s.StudentId == id);
            if (!studentIdExist)
                return false;
            return true;
        }

        public async Task<string> DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            var trans = _studentRepository.BeginTransaction();
            try
            {

                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Student Deleted Successfully";
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                return "Student Deleted Failed";
            }

        }

        public IQueryable<Student> GetStudentsQuerable()
            => _studentRepository.GetTableAsTracking().Include(s => s.Department).AsQueryable();

        public IQueryable<Student> FilterStudentsPaginatedQuerable(StudentOrderingEnum? orderBy, string? search)
        {
            var querable = _studentRepository.GetTableAsTracking().Include(s => s.Department).AsQueryable();
            querable = querable.Where(s => string.IsNullOrEmpty(search) || s.StudentName.Contains(search) || s.StudentAddress.Contains(search));
            if (orderBy != null)
            {
                switch (orderBy)
                {
                    case StudentOrderingEnum.StudentNameAsc:
                        querable = querable.OrderBy(s => s.StudentName);
                        break;
                    case StudentOrderingEnum.StudentNameDesc:
                        querable = querable.OrderByDescending(s => s.StudentName);
                        break;
                    case StudentOrderingEnum.StudentAddressAsc:
                        querable = querable.OrderBy(s => s.StudentAddress);
                        break;
                    case StudentOrderingEnum.StudentAddressDesc:
                        querable = querable.OrderByDescending(s => s.StudentAddress);
                        break;
                    case StudentOrderingEnum.DepartmentNameAsc:
                        querable = querable.OrderBy(s => s.Department.DepartmentName);
                        break;
                    case StudentOrderingEnum.DepartmentNameDesc:
                        querable = querable.OrderByDescending(s => s.Department.DepartmentName);
                        break;
                    case StudentOrderingEnum.StudentNumberAsc:
                        querable = querable.OrderBy(s => s.StudentId);
                        break;
                    case StudentOrderingEnum.StudentNumberDesc:
                        querable = querable.OrderByDescending(s => s.StudentId);
                        break;
                    default:
                        break;
                }
            }
            return querable;
        }



        #endregion
    }
}
