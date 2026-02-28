using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class DeleteStudentValidator : AbstractValidator<DeleteStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public DeleteStudentValidator(IStudentService studentService,
            IStringLocalizer<SharedResources> stringLocalizer)
        {
            _studentService = studentService;
            _localizer = stringLocalizer;
            ValidateDeleteStudentCommand();
            ApplyCustomValidationsRules();
        }
        #endregion


        #region Actions
        public void ValidateDeleteStudentCommand()
        {
            RuleFor(x => x.StudentId)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
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
                .WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
        }
        #endregion

    }
}
