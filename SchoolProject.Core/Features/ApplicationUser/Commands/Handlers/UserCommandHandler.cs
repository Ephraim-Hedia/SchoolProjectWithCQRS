using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler
        , IRequestHandler<AddUserCommand, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        #endregion


        #region Constructors
        public UserCommandHandler(
            IMapper mapper,
            UserManager<User> userManager,
            IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _mapper = mapper;
            _userManager = userManager;
            _localizer = stringLocalizer;
        }
        #endregion



        #region Handle Functions
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            // Check if the email is exist 
            var isEmailExist = await _userManager.FindByEmailAsync(request.Email);

            if (isEmailExist != null)
                return BadRequest<string>(_localizer[SharedResourcesKeys.EmailIsExist]);

            // Check if the UserName is Exist or not 
            var isUserNameExist = await _userManager.FindByNameAsync(request.UserName);
            if (isUserNameExist != null)
                return BadRequest<string>(_localizer[SharedResourcesKeys.UserNameIsExist]);


            // Create New User
            var identityUser = _mapper.Map<User>(request);
            var createResult = await _userManager.CreateAsync(identityUser, request.Password);

            if (!createResult.Succeeded)
                return BadRequest<string>(createResult.Errors.FirstOrDefault().Description);

            return Created("");
        }
        #endregion
    }
}
