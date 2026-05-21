using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core.Features.Projects.Queries.Results
{
    public class GetProjectsByUserIdResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? UserName { get; set; }
        public List<ProjectTaskResponse> Tasks { get; set; } = new();
    }
}
