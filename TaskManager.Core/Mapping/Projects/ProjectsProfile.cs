using AutoMapper;

namespace TaskManager.Core.Mapping.Projects
{
    public partial class ProjectsProfile : Profile
    {
        public ProjectsProfile()
        {
            MapProjectQueries();
            CreateProjectCommandsMapping();
            EditProjectCommandsMapping();
        }
    }
}
