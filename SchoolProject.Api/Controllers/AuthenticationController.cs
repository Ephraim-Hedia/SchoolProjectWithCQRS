
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {
        [HttpPost]
        [Route(Router.AuthenticationRouting.signIn)]
        public async Task<IActionResult> CreateStudent([FromBody] SignInCommand command)
            => NewResult(await Mediator.Send(command));
    }
}
