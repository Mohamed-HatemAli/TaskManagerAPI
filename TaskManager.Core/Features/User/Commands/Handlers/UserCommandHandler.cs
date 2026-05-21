using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Project_Task_Management.Data.Entities.Identity;
using TaskManager.Core.Bases;
using TaskManager.Core.Features.User.Commands.Models;

namespace TaskManager.Core.Features.User.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
     IRequestHandler<AddUserCommand, Response<string>>
    {
        #region Fields
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public UserCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userManager.FindByEmailAsync(request.Email);
            if (userExist != null) return BadRequest<string>("Email already exists.");

            var user = _mapper.Map<ApplicationUser>(request);

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return BadRequest<string>(string.Join(",", result.Errors.Select(x => x.Description)));

            return Success("User registered successfully.");
        }
        #endregion
    }
}
