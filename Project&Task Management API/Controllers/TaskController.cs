using Microsoft.AspNetCore.Mvc;
using Project_Task_Management_API.Base;
using TaskManager.Core.Features.Tasks.Commands.Models;
using static Project_Task_Management.Data.AppMetaData.Router;

namespace Project_Task_Management_API.Controllers
{
    [ApiController]
    public class TaskController : AppControllerBase
    {
        [HttpPost(TaskRouting.Create)]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
    }
}
