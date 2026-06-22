using Microsoft.EntityFrameworkCore;
using Project_Task_Management.Data.Entities;
using TaskManager.Infrastructure.Abstracts;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.InfrastructureBases;

namespace TaskManager.Infrastructure.Repositories
{
    public class ProjectRepository : GenericRepositoryAsync<Project>, ITaskManagerRepository
    {

        #region Fields
        private readonly DbSet<Project> _projects;
        #endregion

        #region Constructors
        public ProjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _projects = dbContext.Set<Project>();
        }
        #endregion

        #region Handle Functions

        public async Task<List<Project>> GetProjectsByUserIdAsync(int userId)
        {
            return await GetTableWithIncludes(p => p.Tasks, p => p.User)
                         .Where(p => p.UserId == userId)
                         .ToListAsync();
        }

        public async Task<Project?> GetProjectByNameAsync(string name)
        {
            return await _projects.AsNoTracking().FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<bool> IsProjectNameExistsAsync(string name, int excludeId)
        {
            return await _projects
                .AsNoTracking()
                .AnyAsync(p => p.Name == name && p.Id != excludeId);
        }

        public async Task<Project?> GetProjectByIdWithTasksAsync(int id)
        {
            return await _projects
                .Include(p => p.Tasks)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Project>> GetAllProjectsWithTasksAsync()
        {
            return await _projects
                .Include(p => p.Tasks)
                .ToListAsync();
        }
        #endregion
    }
}

