using AutoMapper;
using MediatR;
using Project_Task_Management.Data.Entities;
using TaskManager.Core.Bases;
using TaskManager.Core.Features.Tasks.Commands.Models;
using TaskManager.Infrastructure.Abstracts;
using TaskManager.Service.Abstracts;

namespace TaskManager.Core.Features.Tasks.Commands.Handlers
{
    public class TaskCommandHandler : ResponseHandler,
      IRequestHandler<CreateTaskCommand, Response<string>>,
      IRequestHandler<DeleteTaskCommand, Response<string>>,
          IRequestHandler<UpdateTaskStatusCommand, Response<string>>
    {
        private readonly ITaskManagerService _service;
        private readonly IMapper _mapper;
        private readonly ITaskManagerRepository _Projectrepository;
        private readonly ITaskRepository _Taskrepository;



        public TaskCommandHandler(ITaskManagerService service, IMapper mapper, ITaskManagerRepository repository, ITaskRepository taskrepository)
        {
            _service = service;
            _mapper = mapper;
            _Projectrepository = repository;
            _Taskrepository = taskrepository;
        }

        public async Task<Response<string>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<ProjectTask>(request);

            var result = await _service.CreateTaskAsync(request.ProjectId, task);

            return result switch
            {
                "Success" => Created("Task Added Successfully"),
                "ProjectNotFound" => NotFound<string>("Project is Not Found"),
                _ => BadRequest<string>("Something went wrong")
            };
        }

        public async Task<Response<string>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            // 1. The Handler communicates with the Repository to fetch data only
            var project = await _Projectrepository.GetProjectByIdWithTasksAsync(request.ProjectId);

            // 2. This is where the LOGIC and BUSINESS RULES live! (The Handler does the thinking)
            if (project == null)
            {
                return NotFound<string>("Project not found.");
            }

            var task = project.Tasks.FirstOrDefault(t => t.Id == request.TaskId);
            if (task == null)
            {
                return BadRequest<string>("This task does not belong to the specified project.");
            }

            // 3. Once the business logic passes, the Handler instructs the Repository to execute the deletion in the DB
            await _Taskrepository.DeleteAsync(task); // This method is inherited from the Generic Repository

            return Success("Task deleted successfully.");
        }


        public async Task<Response<string>> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var project = await _Projectrepository.GetByIdAsync(request.projectId);
            if (project == null)
            {
                return NotFound<string>("Project not found.");
            }

            var task = await _Taskrepository.GetByIdAsync(request.taskId);
            if (task == null)
            {
                return NotFound<string>("Task not found.");
            }

            if (task.ProjectId != request.projectId)
            {
                return BadRequest<string>("This task does not belong to the specified project.");
            }

            task.Status = request.newStatus;

            await _Taskrepository.UpdateAsync(task);

            return Success("Task status updated successfully.");
        }


    }
}
