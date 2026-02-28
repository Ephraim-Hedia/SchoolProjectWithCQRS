using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class AddStudentCommandHandler :
        ResponseHandler,
        IRequestHandler<AddStudentCommand, Response<string>>,
        IRequestHandler<EditStudentCommand, Response<string>>,
        IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public AddStudentCommandHandler(
            IStudentService studentService,
            IMapper mapper,
            IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _mapper = mapper;
            _studentService = studentService;
        }
        #endregion

        #region Handlers
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            // Mapping the request to the Student entity
            var studentEntity = _mapper.Map<Student>(request);

            // add the student to the database using the service
            var response = await _studentService.CreateStudentAsync(studentEntity);

            // Check if the response indicates a failure (e.g., student name already exists)
            if (response == "Student Created Successfully")
            {
                return Created(response);
            }
            return BadRequest<string>(response);

        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            // Mapping the request to the Student entity
            var studentEntity = _mapper.Map<Student>(request);

            // add the student to the database using the service
            var response = await _studentService.EditStudentAsync(studentEntity);

            // Check if the response indicates a failure (e.g., student name already exists)
            if (response == "Student Updated Successfully")
            {
                return Updated(response);
            }
            return BadRequest<string>(response);
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var response = await _studentService.DeleteStudentAsync(request.StudentId);
            if (response == "Student Deleted Successfully")
            {
                return Deleted<string>(response);
            }
            return BadRequest<string>(response);
        }

        #endregion
    }
}
