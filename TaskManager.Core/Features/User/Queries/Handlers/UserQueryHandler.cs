using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project_Task_Management.Data.Entities.Identity;
using TaskManager.Core.Bases;
using TaskManager.Core.Features.User.Queries.Models;
using TaskManager.Core.Features.User.Queries.Results;

namespace TaskManager.Core.Features.User.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler,
          IRequestHandler<GetUserListQuery, Response<List<GetUserListResponse>>>,
          IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserQueryHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Response<List<GetUserListResponse>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var mappedUserList = await _userManager.Users
                .ProjectTo<GetUserListResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return Success(mappedUserList);
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (user == null)
            {
                return NotFound<GetUserByIdResponse>("User not found.");
            }

            var mappedUser = _mapper.Map<GetUserByIdResponse>(user);

            return Success(mappedUser);
        }
    }
}

