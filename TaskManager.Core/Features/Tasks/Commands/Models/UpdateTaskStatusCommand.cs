using MediatR;
using TaskManager.Core.Bases;

namespace TaskManager.Core.Features.Tasks.Commands.Models
{
    public record class UpdateTaskStatusCommand(int projectId, int taskId, Project_Task_Management.Data.Entities.TaskStatus newStatus) : IRequest<Response<string>>;
}
