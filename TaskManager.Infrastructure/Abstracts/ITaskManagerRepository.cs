using Project_Task_Management.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure.InfrastructureBases;

namespace TaskManager.Infrastructure.Abstracts
{
    public interface ITaskManagerRepository : IGenericRepositoryAsync<Project>
    {
       public Task<List<Project>> GetProjectsByUserIdAsync(int userId);


    }
}
