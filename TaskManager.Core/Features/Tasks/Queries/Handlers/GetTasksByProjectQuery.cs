using AutoMapper;
using MediatR;
using TaskManager.Core.Bases;
using TaskManager.Core.Features.Tasks.Queries.Models;
using TaskManager.Core.Features.Tasks.Queries.Results;
using TaskManager.Infrastructure.Abstracts;

namespace TaskManager.Core.Features.Tasks.Queries.Handlers
{
    public class TaskQueryHandler : ResponseHandler,
         IRequestHandler<GetTasksByProjectQuery, Response<List<GetTasksByProjectResponse>>>
    {
        private readonly ITaskManagerRepository _repository;
        private readonly IMapper _mapper;

        public TaskQueryHandler(ITaskManagerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<GetTasksByProjectResponse>>> Handle(GetTasksByProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetProjectByIdWithTasksAsync(request.ProjectId);

            if (project == null)
            {
                return NotFound<List<GetTasksByProjectResponse>>("Project not found");
            }

            var taskListMapper = _mapper.Map<List<GetTasksByProjectResponse>>(project.Tasks);

            return Success(taskListMapper);
        }
    }
}
