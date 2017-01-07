using Microsoft.Extensions.DependencyInjection;

namespace Amelia.WebApp.Models.DependencyInjection
{
    public interface IDependencyInstaller
    {
          void Install();
    }
}