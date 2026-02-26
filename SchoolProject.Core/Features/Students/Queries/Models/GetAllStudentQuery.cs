using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetAllStudentQuery : IRequest<Response<IEnumerable<GetAllStudentResponse>>>
    {

    }
}
