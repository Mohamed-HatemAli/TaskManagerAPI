using AutoMapper;

namespace TaskManager.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile : Profile
    {

        public ApplicationUserProfile()
        {
            CreateUserMapping();

        }
    }
}
