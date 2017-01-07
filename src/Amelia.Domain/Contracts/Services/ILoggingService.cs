using Amelia.Domain.Models;

namespace Amelia.Domain.Contracts.Services
{
    public interface ILoggingService
    {
         void Add(Error error);
    }
}