using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {

        #region Fields
        private readonly IStudentService _studentService;
        #endregion

        #region Constructors
        public EditStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ValidateAddStudentCommand();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        public void ValidateAddStudentCommand()
        {
            RuleFor(x => x.StudentName)
                .NotEmpty().WithMessage("StudentName is required.")
                .NotNull().WithMessage("StudentName is required.")
                .MaximumLength(50).WithMessage("StudentName Max Length is 50 Char.");


            RuleFor(x => x.StudentAddress)
                .NotEmpty().WithMessage("StudentAddress is required.")
                .NotNull().WithMessage("StudentAddress is required.")
                .MaximumLength(100).WithMessage("StudentAddress Max Length is 100 Char.");


            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone is required.")
                .MaximumLength(11).WithMessage("Phone Max Length is 11 digit.");

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("DepartmentId is required.")
                .GreaterThan(0).WithMessage("DepartmentId must be greater than 0.");
        }


        public void ApplyCustomValidationsRules()
        {
            // Add any custom validation logic here if needed
            // For example, you can check if the student name already exists in the database
            RuleFor(x => x.StudentName)
                .MustAsync(async (model, name, cancellation) =>
                {
                    return !await _studentService.IsNameExistExcludeSelfAsync(name, model.StudentId);
                })
                .WithMessage("A student with the same name already exists.");



            // check if the student id exists in the database
            RuleFor(x => x.StudentId)
                .MustAsync(async (id, cancellation) =>
                {
                    return await _studentService.IsStudentIdExistAsync(id);
                })
                .WithMessage("Student with the specified ID does not exist.");
            // to be added : check if the department id exists in the database
        }
        #endregion
    }
}
