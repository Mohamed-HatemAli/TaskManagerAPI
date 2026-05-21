using TaskManager.Core.Features.User.Commands.Models;

namespace TaskManager.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void CreateUserMapping()
        {

            CreateMap<AddUserCommand, Project_Task_Management.Data.Entities.Identity.ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
        }
    }
}
