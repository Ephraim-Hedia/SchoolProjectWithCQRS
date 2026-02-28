using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {

        #region Fields
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public EditStudentValidator(IStudentService studentService,
            IStringLocalizer<SharedResources> stringLocalizer)
        {
            _studentService = studentService;
            _localizer = stringLocalizer;
            ValidateAddStudentCommand();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        public void ValidateAddStudentCommand()
        {
            RuleFor(x => x.StudentName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(50).WithMessage("StudentName Max Length is 50 Char.");


            RuleFor(x => x.StudentAddress)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage("StudentAddress Max Length is 100 Char.");


            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(11).WithMessage("Phone Max Length is 11 digit.");

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
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
