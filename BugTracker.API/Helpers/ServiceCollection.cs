using AutoMapper;
using BugTracker.API.Data;
using BugTracker.API.Implementation;
using BugTracker.API.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BugTracker.API.Helpers
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(optionsAction: x => x.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddCors();
            services.AddAutoMapper(typeof(BugTrackerRepository).Assembly);
            services.AddScoped<IAuthRepository, AuthRepository>(); // services created 1 per request
            services.AddScoped<IBugTrackerRepository, BugTrackerRepository>(); // services created 1 per request
            services.AddScoped<ICompanyRepository, CompanyRepository>(); // services created 1 per request
            services.AddScoped<IEmployeeRepository, EmployeeRepository>(); // services created 1 per request
            services.AddScoped<IProjectRepository, ProjectRepository>(); // services created 1 per request
            services.AddScoped<ITaskRepository, TaskRepository>(); // services created 1 per request
            services.AddScoped<ITeamRepository, TeamRepository>(); // services created 1 per request
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return services;
        }
    }
}