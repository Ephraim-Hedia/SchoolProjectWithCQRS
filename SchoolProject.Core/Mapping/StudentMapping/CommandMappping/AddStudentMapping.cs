
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void AddStudentMapping()
        {
            CreateMap<AddStudentCommand, Student>()
                .ForMember(dest => dest.StudentNameAr, opt => opt.MapFrom(src => src.StudentNameAr))
                .ForMember(dest => dest.StudentNameEn, opt => opt.MapFrom(src => src.StudentNameEn)).ReverseMap();
        }
    }
}
