using MediatR;
using Project_Task_Management.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Bases;
using TaskManager.Core.Features.Projects.Queries.Results;

namespace TaskManager.Core.Features.Projects.Queries.Models
{
    public class GetProjectsByUserIdQuery : IRequest<Response<List<GetProjectsByUserIdResponse>>>
    {
        #region Properties
        public int UserId { get; set; }
        #endregion

        #region Constructors
        public GetProjectsByUserIdQuery(int userId)
        {
            UserId = userId;
        }
        #endregion
    }
}
