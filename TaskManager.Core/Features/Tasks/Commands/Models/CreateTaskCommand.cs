using MediatR;
using TaskManager.Core.Bases;

namespace TaskManager.Core.Features.Tasks.Commands.Models
{
    public class CreateTaskCommand : IRequest<Response<string>>
    {
        public int ProjectId { get; set; }
        public string title { get; set; }
        public string isCompleted { get; set; }
    }
}
