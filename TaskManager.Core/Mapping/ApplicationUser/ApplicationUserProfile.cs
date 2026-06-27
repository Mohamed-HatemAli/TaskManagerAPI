using AutoMapper;

namespace TaskManager.Core.Mapping
{
    public partial class ApplicationUserProfile : Profile
    {

        public ApplicationUserProfile()
        {
            CreateUserMapping();
            GetUserMapping();

        }
    }
}
