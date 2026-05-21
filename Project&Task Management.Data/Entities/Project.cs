using Project_Task_Management.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Task_Management.Data.Entities
{
    public class Project
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty; 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 

        public int UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public ICollection<ProjectTask> Tasks { get; set; } = [];
    }
}
