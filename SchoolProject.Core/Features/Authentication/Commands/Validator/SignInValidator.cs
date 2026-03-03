using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.Features.Authentication.Commands.Validator
{
    public class SignInValidator : AbstractValidator<SignInCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public SignInValidator(IStudentService studentService,
            IStringLocalizer<SharedResources> stringLocalizer,
            IDepartmentService departmentService)
        {
            _localizer = stringLocalizer;
            ValidateSignInCommand();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ValidateSignInCommand()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }

        public void ApplyCustomValidationsRules()
        {
            // Add any custom validation rules here if needed
        }
        #endregion
    }
}
