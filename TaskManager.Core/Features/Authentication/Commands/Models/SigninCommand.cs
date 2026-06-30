using MediatR;
using TaskManager.Core.Bases;

namespace TaskManager.Core.Features.Authentication.Commands.Models
{
    public class SigninCommand : IRequest<Response<string>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
