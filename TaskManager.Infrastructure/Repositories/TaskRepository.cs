using Microsoft.EntityFrameworkCore;
using Project_Task_Management.Data.Entities;
using TaskManager.Infrastructure.Abstracts;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.InfrastructureBases;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskRepository : GenericRepositoryAsync<ProjectTask>, ITaskRepository
    {
        #region Fields
        private readonly DbSet<ProjectTask> _ProjectTask;
        #endregion

        #region Constructors
        public TaskRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _ProjectTask = dbContext.Set<ProjectTask>();
        }
        #endregion
    }
}
