using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Departments.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Interfaces;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Departments.Queries.Handlers
{
    public class GetDepartmentByIdHandler : ResponseHandler, IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        #endregion
        #region Constructors
        public GetDepartmentByIdHandler(IDepartmentService departmentService,
            IMapper mapper,
            IStudentService studentService,
            IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _departmentService = departmentService;
            _mapper = mapper;
            _studentService = studentService;
        }

        #endregion
        #region Handle Functions
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            // Call Service to get the department by id include the students and instructors and subjects in this department
            var department = await _departmentService.GetDepartmentByIdAsync(request.DepartmentId);
            // check if the department is null return not found response
            if (department == null)
            {
                return NotFound<GetDepartmentByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }
            // map the department to GetDepartmentByIdResponse and return it in success response
            var response = _mapper.Map<GetDepartmentByIdResponse>(department);

            // Pagination 
            Expression<Func<Student, StudentResponse>> expression = s
                => new StudentResponse(s.StudentId, s.GetLocalizedName(s.StudentNameAr, s.StudentNameEn));

            var studentsQuarable = _studentService.GetStudentsByDepartmentIdQuerable(department.DepeartmentId);
            var paginatedList = await studentsQuarable.Select(expression).ToPaginatedListAsync(request.StudentsPageNumber, request.StudentsPageSize);
            response.StudentList = paginatedList;
            // if any error occurs return unprocessable entity response with the error message
            return response == null ? UnprocessableEntity<GetDepartmentByIdResponse>(_stringLocalizer[SharedResourcesKeys.UnprocessableEntity]) : Success(response);
        }

        #endregion


    }
}
