using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Features.ApplicationUser.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        [HttpPost]
        [Route(Router.ApplicationUserRouting.create)]
        public async Task<IActionResult> CreateNewUser([FromBody] AddUserCommand command)
            => NewResult(await Mediator.Send(command));

        [HttpGet]
        [Route(Router.ApplicationUserRouting.getAllPaginated)]
        public async Task<IActionResult> GetAllUsersPaginatedList([FromQuery] GetUserPaginatedQuery query)
             => Ok(await Mediator.Send(query));

        [HttpGet]
        [Route(Router.ApplicationUserRouting.getById)]
        public async Task<IActionResult> GetUserById(int id)
             => Ok(await Mediator.Send(new GetUserByIdQuery(id)));

        [HttpPut]
        [Route(Router.ApplicationUserRouting.update)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
            => NewResult(await Mediator.Send(command));
    }
}
