using MediatR;
using TaskManager.Core.Bases;

namespace TaskManager.Core.Features.Tasks.Commands.Models
{
    public record DeleteTaskCommand(int ProjectId, int TaskId) : IRequest<Response<string>>;
}
