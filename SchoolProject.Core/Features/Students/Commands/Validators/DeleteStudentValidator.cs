using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class DeleteStudentValidator : AbstractValidator<DeleteStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        #endregion

        #region Constructors
        public DeleteStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ValidateDeleteStudentCommand();
            ApplyCustomValidationsRules();
        }
        #endregion


        #region Actions
        public void ValidateDeleteStudentCommand()
        {
            RuleFor(x => x.StudentId)
                .NotEmpty().WithMessage("StudentId is required.")
                .GreaterThan(0).WithMessage("StudentId must be greater than 0.");
        }
        public void ApplyCustomValidationsRules()
        {
            // check if the student id exists in the database
            RuleFor(x => x.StudentId)
                .MustAsync(async (id, cancellation) =>
                {
                    return await _studentService.IsStudentIdExistAsync(id);
                })
                .WithMessage("Student with the specified ID does not exist.");
        }
        #endregion

    }
}
