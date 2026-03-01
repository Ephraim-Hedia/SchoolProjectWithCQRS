using AutoMapper;
using SchoolProject.Core.Features.Departments.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile : Profile
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
                .ForMember(dest => dest.DepeartmentId, opt => opt.MapFrom(src => src.DepeartmentId))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.GetLocalizedName(src.DepartmentNameAr, src.DepartmentNameEn)))
                .ForMember(dest => dest.SubjectList, opt => opt.MapFrom(src => src.DepartmentSubjects))
                .ForMember(dest => dest.StudentList, opt => opt.MapFrom(src => src.Students))
                .ForMember(dest => dest.InstructorList, opt => opt.MapFrom(src => src.Instructors))
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.InstructorDepartmentManager.GetLocalizedName(src.InstructorDepartmentManager.InstructorNameAr, src.InstructorDepartmentManager.InstructorNameEn)));


            CreateMap<Student, StudentResponse>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.GetLocalizedName(src.StudentNameAr, src.StudentNameEn)));

            CreateMap<DepartmentSubject, SubjectResponse>()
               .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubjectId))
               .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.GetLocalizedName(src.Subject.SubjectNameAr, src.Subject.SubjectNameEn)));

            CreateMap<Instructor, InstructorResponse>()
               .ForMember(dest => dest.InstructorId, opt => opt.MapFrom(src => src.InstructorId))
               .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.GetLocalizedName(src.InstructorNameAr, src.InstructorNameEn)));
        }
    }
}
