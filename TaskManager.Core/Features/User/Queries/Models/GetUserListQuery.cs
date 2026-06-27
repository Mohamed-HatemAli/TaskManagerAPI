using MediatR;
using TaskManager.Core.Bases;
using TaskManager.Core.Features.User.Queries.Results;

namespace TaskManager.Core.Features.User.Queries.Models
{
    public class GetUserListQuery : IRequest<Response<List<GetUserListResponse>>>
    {



    }
}
