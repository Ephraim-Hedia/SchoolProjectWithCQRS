using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<Response<string>>
    {
        public string StudentNameAr { get; set; }
        public string StudentNameEn { get; set; }
        public string StudentAddress { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
