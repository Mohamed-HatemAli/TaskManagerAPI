using Microsoft.Extensions.DependencyInjection;
using TaskManager.Service.Abstracts;
using TaskManager.Service.Implementations;

namespace TaskManager.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            #region Service Register
            services.AddTransient<ITaskManagerService, TaskManagerService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            #endregion

            return services;
        }

    }
}
