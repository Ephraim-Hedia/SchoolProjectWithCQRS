using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;
namespace SchoolProject.Api.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    public class StudentController : AppControllerBase
    {
        [HttpGet(Router.studentRouting.getAll)]
        public async Task<IActionResult> GetAllStudents()
            => NewResult(await Mediator.Send(new GetAllStudentQuery()));

        [HttpGet(Router.studentRouting.getAllPaginated)]
        public async Task<IActionResult> GetAllStudentsPaginatedList([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }



        [HttpGet(Router.studentRouting.getById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
            => NewResult(await Mediator.Send(new GetStudentByIdQuery() { StudentId = id }));

        [HttpPost]
        [Route(Router.studentRouting.create)]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentCommand command)
            => NewResult(await Mediator.Send(command));

        [HttpPut]
        [Route(Router.studentRouting.update)]
        public async Task<IActionResult> UpdateStudent([FromBody] EditStudentCommand command)
            => NewResult(await Mediator.Send(command));

        [HttpDelete]
        [Route(Router.studentRouting.delete)]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
            => NewResult(await Mediator.Send(new DeleteStudentCommand() { StudentId = id }));

    }
}
