using MediatR;
using TaskManager.Core.Bases;
using TaskManager.Core.Features.Tasks.Queries.Results;

namespace TaskManager.Core.Features.Tasks.Queries.Models
{
    public class GetTasksByProjectQuery : IRequest<Response<List<GetTasksByProjectResponse>>>
    {
        public int ProjectId { get; set; }

        public GetTasksByProjectQuery(int projectId)
        {
            ProjectId = projectId;
        }
    }
}
