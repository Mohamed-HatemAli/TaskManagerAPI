using Project_Task_Management.Data.Entities;
using TaskManager.Core.Features.Projects.Commands.Models;

namespace TaskManager.Core.Mapping.Projects
{
    public partial class ProjectsProfile
    {
        public void CreateProjectCommandsMapping()
        {
            CreateMap<CreateProjectCommand, Project>();
        }
    }
}
