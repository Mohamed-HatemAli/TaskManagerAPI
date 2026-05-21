using Microsoft.EntityFrameworkCore;
using Project_Task_Management.Data.Entities;
using TaskManager.Infrastructure.Abstracts;
using TaskManager.Service.Abstracts;

namespace TaskManager.Service.Implementations
{
    public class TaskManagerService : ITaskManagerService
    {

        #region Fields
        private readonly ITaskManagerRepository _TaskManagerRepository;
        #endregion

        #region Constructors
        public TaskManagerService(ITaskManagerRepository TaskManagerRepository)
        {
            _TaskManagerRepository = TaskManagerRepository;
        }
        #endregion

        #region Handle Functions
        public async Task<List<Project>> GetProjectsByUserIdAsync(int userId)
        {
            return await _TaskManagerRepository.GetProjectsByUserIdAsync(userId);
        }

        public async Task<string> AddProjectAsync(Project project)
        {

            var projectExist = await _TaskManagerRepository.GetTableNoTracking()
                                                           .Where(p => p.Name == project.Name)
                                                           .FirstOrDefaultAsync();

            if (projectExist != null) return "Exist";

            await _TaskManagerRepository.AddAsync(project);
            return "Success";
        }

        public async Task<string> EditProjectAsync(Project project)
        {

            var projectExist = await _TaskManagerRepository.GetTableNoTracking()
                                                           .Where(p => p.Name == project.Name && p.Id != project.Id)
                                                           .FirstOrDefaultAsync();

            if (projectExist != null) return "NameAlreadyExists";

            try
            {
                await _TaskManagerRepository.UpdateAsync(project);
                return "Success";
            }
            catch (Exception)
            {
                return "Failed";
            }
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _TaskManagerRepository.GetTableWithIncludes(p => p.Tasks)
                                               .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<string> DeleteAsync(Project project)
        {
            var trans = _TaskManagerRepository.BeginTransaction();
            try
            {
                await _TaskManagerRepository.DeleteAsync(project);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Falied";
            }
        }
        #endregion

        public async Task<List<Project>> GetProjectListAsync()
        {
            return await _TaskManagerRepository.GetTableWithIncludes(p => p.Tasks)
                                               .ToListAsync();
        }


    }
}
