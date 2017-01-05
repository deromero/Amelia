using Amelia.WebApi.Models.Entities;

namespace Amelia.WebApi.Models.Contracts.Repositories
{
    public interface IUserRepository : IEntityBaseRepository<User>
    {
        User Find(string username, string hashedPassword);
    }
}