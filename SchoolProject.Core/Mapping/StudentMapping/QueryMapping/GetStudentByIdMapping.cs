
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void GetStudentByIdMapping()
        {
            CreateMap<Student, GetStudentByIdResponse>()
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.GetLocalizedName(src.StudentNameAr, src.StudentNameEn)))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.GetLocalizedName(src.Department.DepartmentNameAr, src.Department.DepartmentNameEn)));
        }
    }
}
