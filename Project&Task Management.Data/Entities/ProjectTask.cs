using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Task_Management.Data.Entities
{
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Completed
    }

    public enum TaskPriority
    {
        Low,
        Medium,
        High
    }

    public class ProjectTask
    {     
            public int Id { get; set; } 
            public string Title { get; set; } = string.Empty; 
            public string Description { get; set; } = string.Empty; 
            public TaskStatus Status { get; set; } = TaskStatus.Pending; 
            public DateTime DueDate { get; set; } 
            public TaskPriority Priority { get; set; } = TaskPriority.Medium; 
            public int ProjectId { get; set; } 
            public Project Project { get; set; } = null!;
        
    }
}
