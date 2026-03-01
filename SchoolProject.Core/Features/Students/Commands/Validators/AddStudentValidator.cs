using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IDepartmentService _departmentService;
        #endregion

        #region Constructors
        public AddStudentValidator(IStudentService studentService,
            IStringLocalizer<SharedResources> stringLocalizer,
            IDepartmentService departmentService)
        {
            _studentService = studentService;
            _departmentService = departmentService;
            _localizer = stringLocalizer;
            ValidateAddStudentCommand();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        public void ValidateAddStudentCommand()
        {
            RuleFor(x => x.StudentNameAr)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(50).WithMessage("StudentName Max Length is 50 Char.");

            RuleFor(x => x.StudentNameEn)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(50).WithMessage("StudentName Max Length is 50 Char.");

            RuleFor(x => x.StudentAddress)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(SharedResourcesKeys.MaxLengthis100);


            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .MaximumLength(11).WithMessage("Phone Max Length is 11 digit.");

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .GreaterThan(0).WithMessage("DepartmentId must be greater than 0.");
        }


        public void ApplyCustomValidationsRules()
        {
            // Add any custom validation logic here if needed
            // For example, you can check if the student name already exists in the database
            RuleFor(x => x.StudentNameEn)
                .MustAsync(async (name, cancellation) =>
                {
                    return !await _studentService.IsNameExistAsync(name);
                })
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.StudentNameAr)
                .MustAsync(async (name, cancellation) =>
                {
                    return !await _studentService.IsNameExistAsync(name);
                })
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            // to be added : check if the department id exists in the database
            RuleFor(x => x.DepartmentId)
                .MustAsync(async (id, cancellation) =>
                {
                    return await _departmentService.IsDepartmentIdExistAsync(id);
                })
                .WithMessage(_localizer[SharedResourcesKeys.NotFound]);
        }
        #endregion
    }
}
