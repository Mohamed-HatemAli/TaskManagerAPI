using AutoMapper;
using MediatR;
using Project_Task_Management.Data.Entities;
using TaskManager.Core.Bases;
using TaskManager.Core.Features.Tasks.Commands.Models;
using TaskManager.Service.Abstracts;

namespace TaskManager.Core.Features.Tasks.Commands.Handlers
{
    public class TaskCommandHandler : ResponseHandler,
         IRequestHandler<CreateTaskCommand, Response<string>>
    {
        private readonly ITaskManagerService _service;
        private readonly IMapper _mapper;


        public TaskCommandHandler(ITaskManagerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
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


    }
}
