using Project_Task_Management.Data.Entities;
using TaskManager.Infrastructure.InfrastructureBases;

namespace TaskManager.Infrastructure.Abstracts
{
    public interface ITaskRepository : IGenericRepositoryAsync<ProjectTask>
    {
    }
}
