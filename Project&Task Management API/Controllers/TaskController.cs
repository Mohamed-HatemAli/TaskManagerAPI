using Microsoft.AspNetCore.Mvc;
using Project_Task_Management_API.Base;
using TaskManager.Core.Features.Tasks.Commands.Models;
using TaskManager.Core.Features.Tasks.Queries.Models;
using static Project_Task_Management.Data.AppMetaData.Router;

namespace Project_Task_Management_API.Controllers
{
    [ApiController]
    public class TaskController : AppControllerBase
    {
        [HttpPost(TaskRouting.Create)]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand model, [FromRoute] int projectId)
        {
            var command = new CreateTaskCommand { ProjectId = projectId, title = model.title, isCompleted = model.isCompleted };
            return NewResult(await Mediator.Send(command));
        }

        [HttpGet(TaskRouting.GetTasksByProject)]
        public async Task<IActionResult> GetTasksByProject([FromRoute] int projectId)
        {
            var response = await Mediator.Send(new GetTasksByProjectQuery(projectId));

            return NewResult(response);
        }

        [HttpDelete(TaskRouting.Delete)]
        public async Task<IActionResult> DeleteTask([FromRoute] int projectId, [FromRoute] int taskId)
        {
            var response = await Mediator.Send(new DeleteTaskCommand(projectId, taskId));

            return NewResult(response);
        }

        [HttpPut(TaskRouting.UpdateStatus)]
        public async Task<IActionResult> UpdateTaskStatus([FromRoute] int projectId, [FromRoute] int taskId, [FromBody] Project_Task_Management.Data.Entities.TaskStatus newStatus)
        {
            var response = await Mediator.Send(new UpdateTaskStatusCommand(projectId, taskId, newStatus));

            return NewResult(response);
        }

    }
}
