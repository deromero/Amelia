using Amelia.WebApp.Models.Contracts;
using Amelia.WebApp.Models.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Amelia.WebApp.Models.DependencyInjection
{
    public class AuthenticationInstaller 
    {
        
        public static void Install(IServiceCollection services)
        {
            AddAuthenticationServicesTo(services);
        }

        public static void AddAuthenticationServicesTo(IServiceCollection services)
        {
            services.AddScoped<IMembershipService, MembershipService>();
            services.AddScoped<IEncryptionService, EncryptionService>();

        }
    }
}