using AutoMapper;
using MediatR;
using Project_Task_Management.Data.Entities;
using TaskManager.Core.Bases;
using TaskManager.Core.Features.Projects.Commands.Models;
using TaskManager.Service.Abstracts;

namespace TaskManager.Core.Features.Projects.Commands.Handlers
{
    public class ProjectCommandHandler : ResponseHandler,
        IRequestHandler<CreateProjectCommand, Response<string>>,
        IRequestHandler<EditProjectCommand, Response<string>>,
        IRequestHandler<DeleteProjectCommand, Response<string>>
    {
        private readonly ITaskManagerService _service;
        private readonly IMapper _mapper;

        public ProjectCommandHandler(ITaskManagerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _mapper.Map<Project>(request);

            var result = await _service.AddProjectAsync(project);

            return result switch
            {
                "Success" => Created("Added Successfully"),
                _ => BadRequest<string>("Something went wrong")
            };
        }

        public async Task<Response<string>> Handle(EditProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _service.GetProjectByIdAsync(request.Id);
            if (project == null) return NotFound<string>("Project is Not Found");

            _mapper.Map(request, project);

            var result = await _service.EditProjectAsync(project);

            return result switch
            {
                "Success" => Success("Updated Successfully"),
                "NameAlreadyExists" => BadRequest<string>("Project name already exists in another project"),
                _ => BadRequest<string>("Update Failed")
            };
        }

        public async Task<Response<string>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _service.GetProjectByIdAsync(request.Id);
            if (project == null) return NotFound<string>("Project Not Found");

            var result = await _service.DeleteAsync(project);

            return result == "Success" ? Success("Deleted Successfully") : BadRequest<string>("Delete Failed");
        }
    }
}
