using AutoMapper;

namespace TaskManager.Core.Mapping.Task
{
    public partial class TaskMappingProfile : Profile
    {
        public TaskMappingProfile()
        {
            CreateTaskCommandMapping();


        }
    }
}
