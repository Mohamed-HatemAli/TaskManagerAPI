using Microsoft.EntityFrameworkCore;
using Project_Task_Management.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure.Abstracts;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.InfrastructureBases;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskManagerRepository : GenericRepositoryAsync<Project> , ITaskManagerRepository
    {

        #region Fields
        private readonly DbSet<Project> _projects;
        #endregion

        #region Constructors
        public TaskManagerRepository(ApplicationDbContext dbContext) : base(dbContext)
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
        #endregion
    }
}

