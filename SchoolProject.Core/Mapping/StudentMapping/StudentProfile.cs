using AutoMapper;

namespace SchoolProject.Core.Mapping.StudentMapping
{
    public partial class StudentProfile : Profile
    {
        #region constructor
        public StudentProfile()
        {
            GetAllStudentMapping();
            GetStudentByIdMapping();
            AddStudentMapping();
            EditStudentMapping();
        }
        #endregion
    }
}
