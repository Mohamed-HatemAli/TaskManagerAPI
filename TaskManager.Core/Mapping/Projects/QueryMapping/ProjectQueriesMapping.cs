using Project_Task_Management.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Features.Projects.Queries.Results;

namespace TaskManager.Core.Mapping.Projects
{
    public partial class ProjectsProfile
    {
        public void MapProjectQueries()
        {
            CreateMap<Project, GetProjectsByUserIdResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));

            CreateMap<ProjectTask, ProjectTaskResponse>();
        }
    }
}
