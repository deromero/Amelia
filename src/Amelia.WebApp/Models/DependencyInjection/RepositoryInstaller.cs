using Amelia.Data.Repositories;
using Amelia.Domain.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Amelia.WebApp.Models.DependencyInjection
{
    public class RepositoryInstaller
    {
        public static void Install(IServiceCollection services)
        {
            AddGenericRepositoriesTo(services);
        }

        private static void AddGenericRepositoriesTo(IServiceCollection services)
        {
            services.AddScoped<ILoggingRepository, LoggingRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectRoleRepository, ProjectRoleRepository>();
        }

        private static void AddCustomRepositoriesTo(IServiceCollection services)
        {
            // Add custom repositories
        }

    }
}