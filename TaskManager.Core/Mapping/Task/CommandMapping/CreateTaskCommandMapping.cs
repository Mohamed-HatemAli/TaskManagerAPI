using Project_Task_Management.Data.Entities;
using TaskManager.Core.Features.Tasks.Commands.Models;

namespace TaskManager.Core.Mapping.Task
{
    public partial class TaskMappingProfile
    {
        public void CreateTaskCommandMapping()
        {
            CreateMap<CreateTaskCommand, ProjectTask>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.title))

                .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>
                    src.isCompleted == "true" ?
                    Project_Task_Management.Data.Entities.TaskStatus.Completed :
                    Project_Task_Management.Data.Entities.TaskStatus.Pending))

                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => string.Empty))

                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => Project_Task_Management.Data.Entities.TaskPriority.Medium))

                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => DateTime.Now.AddDays(7)));
        }
    }
}
