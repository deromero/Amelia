using Amelia.Domain.Contracts.Services;
using Amelia.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Amelia.WebApp.Models.DependencyInjection
{
    public class ServiceInstaller 
    {

        public static void Install(IServiceCollection services)
        {
            AddServicesTo(services);
        }

        private static void AddServicesTo(IServiceCollection services)
        {
            services.AddScoped<ILoggingService, LoggingService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}