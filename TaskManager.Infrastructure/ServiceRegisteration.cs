using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Project_Task_Management.Data.Entities.Identity;
using Project_Task_Management.Data.Helpers;
using System.Text;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection AddServiceRegisteration(this IServiceCollection services, IConfiguration configuration)
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

            //JWT Authentication Configuration  

            var jwtSettings = new JwtSettings();
            configuration.GetSection("jwtSettings").Bind(jwtSettings);

            services.AddSingleton(jwtSettings);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidIssuers = new[] { jwtSettings.Issuer },
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),

                    ValidAudience = jwtSettings.Audience,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidateLifetime = jwtSettings.ValidateLifetime
                };
            });

            services.AddOpenApi(options =>
           {
               options.AddDocumentTransformer((document, context, cancellationToken) =>
               {
                   var scheme = new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                   {
                       Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                       Name = "Authorization",
                       In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                       Scheme = "bearer",
                       BearerFormat = "JWT",
                       Description = "Enter your JWT token in this format: Bearer {your_token}"
                   };

                   document.Components ??= new Microsoft.OpenApi.Models.OpenApiComponents();
                   document.Components.SecuritySchemes.Add("Bearer", scheme);

                   var requirement = new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                       {
                            {
                                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                                {
                                    Reference = new Microsoft.OpenApi.Models.OpenApiReference
                                    {
                                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    }
                                },
                                Array.Empty<string>()
                            }
                       };

                   document.SecurityRequirements = new List<Microsoft.OpenApi.Models.OpenApiSecurityRequirement> { requirement };
                   return Task.CompletedTask;
               });
           });





            return services;
        }

    }
}

