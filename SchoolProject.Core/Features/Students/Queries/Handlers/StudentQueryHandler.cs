using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Interfaces;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler
        , IRequestHandler<GetAllStudentQuery, Response<IEnumerable<GetAllStudentResponse>>>
        , IRequestHandler<GetStudentByIdQuery, Response<GetStudentByIdResponse>>
        , IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructor
        public StudentQueryHandler(IStudentService studentService
            , IMapper mapper
            , IStringLocalizer<SharedResources> stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _localizer = stringLocalizer;
        }
        #endregion

        #region Handlers
        public async Task<Response<IEnumerable<GetAllStudentResponse>>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetAllStudentsAsync();
            var studentListMapper = _mapper.Map<IEnumerable<Student>, IEnumerable<GetAllStudentResponse>>(studentList);
            return Success(studentListMapper);

        }

        public async Task<Response<GetStudentByIdResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.StudentId);
            if (student == null)
                return NotFound<GetStudentByIdResponse>(_localizer[SharedResourcesKeys.NotFound]);

            var studentMapper = _mapper.Map<GetStudentByIdResponse>(student);
            return Success(studentMapper);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = s
                => new GetStudentPaginatedListResponse(s.StudentId, s.StudentName, s.StudentAddress, s.Department.DepartmentName);
            //var querable = _studentService.GetStudentsQuerable();
            var FilterQuery = _studentService.FilterStudentsPaginatedQuerable(request.OrderBy, request.Search);
            return await FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
        }
        #endregion
    }
}
