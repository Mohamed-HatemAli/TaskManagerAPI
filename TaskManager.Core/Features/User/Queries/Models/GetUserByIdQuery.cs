using MediatR;
using TaskManager.Core.Bases;
using TaskManager.Core.Features.User.Queries.Results;

namespace TaskManager.Core.Features.User.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
