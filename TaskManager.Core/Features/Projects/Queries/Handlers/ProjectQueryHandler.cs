using AutoMapper;
using MediatR;
using TaskManager.Core.Bases;
using TaskManager.Core.Features.Projects.Queries.Models;
using TaskManager.Core.Features.Projects.Queries.Results;
using TaskManager.Service.Abstracts;

namespace TaskManager.Core.Features.Projects.Queries.Handlers
{
    public class ProjectQueryHandler : ResponseHandler,
         IRequestHandler<GetProjectsByUserIdQuery, Response<List<GetProjectsByUserIdResponse>>>, IRequestHandler<GetProjectByIdQuery, Response<GetProjectsByUserIdResponse>>,
            IRequestHandler<GetProjectListQuery, Response<List<GetProjectsByUserIdResponse>>>
    {
        #region Fields
        private readonly ITaskManagerService _taskManagerService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ProjectQueryHandler(ITaskManagerService taskManagerService, IMapper mapper)
        {
            _taskManagerService = taskManagerService;
            _mapper = mapper;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<List<GetProjectsByUserIdResponse>>> Handle(GetProjectsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var projectList = await _taskManagerService.GetProjectsByUserIdAsync(request.UserId);

            var response = _mapper.Map<List<GetProjectsByUserIdResponse>>(projectList);

            return Success(response, "Projects retrieved successfully.");
        }

        public async Task<Response<GetProjectsByUserIdResponse>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _taskManagerService.GetProjectByIdAsync(request.Id);
            if (project == null) return NotFound<GetProjectsByUserIdResponse>("Project not found.");

            var response = _mapper.Map<GetProjectsByUserIdResponse>(project);
            return Success(response);
        }

        public async Task<Response<List<GetProjectsByUserIdResponse>>> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            var projects = await _taskManagerService.GetProjectListAsync();
            var response = _mapper.Map<List<GetProjectsByUserIdResponse>>(projects);
            return Success(response);
        }
        #endregion
    }
}
