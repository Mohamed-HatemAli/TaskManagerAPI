using Project_Task_Management.Data.Entities;
using TaskManager.Core.Features.Tasks.Queries.Results;

namespace TaskManager.Core.Mapping.Task
{
    public partial class TaskMappingProfile
    {
        public void TaskQueriesMapping()
        {
            CreateMap<ProjectTask, GetTasksByProjectResponse>();
        }
    }
}
