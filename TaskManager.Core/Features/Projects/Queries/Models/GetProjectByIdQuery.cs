using MediatR;
using TaskManager.Core.Bases;
using TaskManager.Core.Features.Projects.Queries.Results;

namespace TaskManager.Core.Features.Projects.Queries.Models
{
    public class GetProjectByIdQuery : IRequest<Response<GetProjectsByUserIdResponse>>
    {
        public int Id { get; set; }
        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }
    }


}
