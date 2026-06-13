using Project_Task_Management.Data.Entities;
using TaskManager.Infrastructure.InfrastructureBases;

namespace TaskManager.Infrastructure.Abstracts
{
    public interface ITaskManagerRepository : IGenericRepositoryAsync<Project>
    {
        public Task<List<Project>> GetProjectsByUserIdAsync(int userId);
        public Task<Project?> GetProjectByNameAsync(string name);
        public Task<bool> IsProjectNameExistsAsync(string name, int excludeId);
        public Task<List<Project>> GetAllProjectsWithTasksAsync();
        public Task<Project?> GetProjectByIdWithTasksAsync(int id);




    }
}
