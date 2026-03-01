using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Queries.Results;

namespace SchoolProject.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdResponse>>
    {
        public int DepartmentId { get; set; }
        public int StudentsPageSize { get; set; }
        public int StudentsPageNumber { get; set; }
        public GetDepartmentByIdQuery(int id)
        {
            DepartmentId = id;
        }
    }
}
