using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.departmentRouting.getById)]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
            => NewResult(await Mediator.Send(new GetDepartmentByIdQuery(id)));
    }
}
