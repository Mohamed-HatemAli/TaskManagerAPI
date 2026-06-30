using Project_Task_Management.Data.Entities.Identity;


namespace TaskManager.Service.Abstracts
{
    public interface IAuthenticationService
    {
        public Task<string> GetJWTToken(ApplicationUser user);

    }
}
