using MediatR;
using TaskManager.Core.Bases;

namespace TaskManager.Core.Features.Projects.Commands.Models
{
    public class EditProjectCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }

    }
}
