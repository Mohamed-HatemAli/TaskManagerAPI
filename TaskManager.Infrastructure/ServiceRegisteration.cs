using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project_Task_Management.Data.Entities.Identity;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection AddServiceRegisteration(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole<int>>(option =>
            {
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireUppercase = true;
                option.Password.RequiredLength = 6;

                option.SignIn.RequireConfirmedEmail = false;
            })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

            return services;
        }

    }
}

