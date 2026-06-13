using Microsoft.AspNetCore.Mvc;
using Project_Task_Management_API.Base;
using TaskManager.Core.Features.Projects.Commands.Models;
using TaskManager.Core.Features.Projects.Queries.Models;
using static Project_Task_Management.Data.AppMetaData.Router;

namespace Project_Task_Management_API.Controllers
{

    [ApiController]
    public class ProjectController : AppControllerBase
    {

        #region Routing & Actions

        [HttpGet(ProjectRouting.GetByUserId)]
        public async Task<IActionResult> GetProjectsByUserId([FromRoute] int userId)
        {

            return NewResult(await Mediator.Send(new GetProjectsByUserIdQuery(userId)));
        }

        [HttpPost(ProjectRouting.Create)]
        public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpPut(ProjectRouting.Update)]
        public async Task<IActionResult> Edit([FromBody] EditProjectCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpDelete(ProjectRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteProjectCommand(id)));
        }

        [HttpGet(ProjectRouting.GetById)]
        public async Task<IActionResult> GetProjectById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetProjectByIdQuery(id)));
        }

        [HttpGet(ProjectRouting.List)]
        public async Task<IActionResult> GetAllProjects()
        {
            return NewResult(await Mediator.Send(new GetProjectListQuery()));
        }



        #endregion
    }
}
