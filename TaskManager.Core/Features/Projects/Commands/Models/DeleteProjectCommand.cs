using MediatR;
using TaskManager.Core.Bases;

namespace TaskManager.Core.Features.Projects.Commands.Models
{
    public class DeleteProjectCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteProjectCommand(int id) { Id = id; }
    }
}
