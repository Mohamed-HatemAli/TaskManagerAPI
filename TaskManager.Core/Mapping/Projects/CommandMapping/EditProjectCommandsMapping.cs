using Project_Task_Management.Data.Entities;
using TaskManager.Core.Features.Projects.Commands.Models;

namespace TaskManager.Core.Mapping.Projects
{
    public partial class ProjectsProfile
    {
        public void EditProjectCommandsMapping()
        {
            CreateMap<EditProjectCommand, Project>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
