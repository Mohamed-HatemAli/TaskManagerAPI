using Microsoft.AspNetCore.Identity;

namespace Project_Task_Management.Data.Entities.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; } = string.Empty;
        public ICollection<Project> Projects { get; set; } = [];
    }
}
