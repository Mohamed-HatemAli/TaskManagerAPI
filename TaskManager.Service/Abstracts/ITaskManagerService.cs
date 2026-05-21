using Project_Task_Management.Data.Entities;

namespace TaskManager.Service.Abstracts
{
    public interface ITaskManagerService
    {
        Task<List<Project>> GetProjectsByUserIdAsync(int userId);
        public Task<string> AddProjectAsync(Project project);
        Task<string> EditProjectAsync(Project project);
        Task<Project> GetProjectByIdAsync(int id);
        Task<string> DeleteAsync(Project project);

        Task<List<Project>> GetProjectListAsync();

    }
}
