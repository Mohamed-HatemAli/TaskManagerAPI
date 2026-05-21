using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Bases;

namespace TaskManager.Core.Features.Projects.Commands.Models
{
    public class CreateProjectCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
