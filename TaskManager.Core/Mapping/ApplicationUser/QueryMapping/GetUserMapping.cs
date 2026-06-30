using Project_Task_Management.Data.Entities.Identity;
using TaskManager.Core.Features.User.Queries.Results;



namespace TaskManager.Core.Mapping
{
    public partial class ApplicationUserProfile
    {
        public void GetUserMapping()
        {
            CreateMap<ApplicationUser, GetUserListResponse>();
            CreateMap<ApplicationUser, GetUserByIdResponse>();
        }


    }
}
