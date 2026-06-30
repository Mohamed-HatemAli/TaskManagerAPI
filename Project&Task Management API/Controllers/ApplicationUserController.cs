using Microsoft.AspNetCore.Mvc;
using Project_Task_Management_API.Base;
using TaskManager.Core.Features.User.Commands.Models;
using TaskManager.Core.Features.User.Queries.Models;
using static Project_Task_Management.Data.AppMetaData.Router;

namespace Project_Task_Management_API.Controllers
{

    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {

        [HttpPost(UserRouting.Register)]
        public async Task<IActionResult> Register([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }

        [HttpGet(UserRouting.List)]
        public async Task<IActionResult> GetUserList()
        {
            var response = await Mediator.Send(new GetUserListQuery());

            return NewResult(response);
        }

        [HttpGet(UserRouting.GetById)]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetUserByIdQuery(id));
            return NewResult(response);
        }

    }
}
