using Microsoft.AspNetCore.Mvc;
using Project_Task_Management_API.Base;
using TaskManager.Core.Features.User.Commands.Models;

namespace Project_Task_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }

    }
}
