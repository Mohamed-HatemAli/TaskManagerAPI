using MediatR;
using TaskManager.Core.Bases;
using TaskManager.Core.Features.Projects.Queries.Results;

namespace TaskManager.Core.Features.Projects.Queries.Models
{
    public class GetProjectListQuery : IRequest<Response<List<GetProjectsByUserIdResponse>>>
    {
        public GetProjectListQuery()
        {
        }
    }
}
