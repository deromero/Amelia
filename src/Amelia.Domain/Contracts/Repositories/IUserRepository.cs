using System.Collections.Generic;
using Amelia.Domain.Models;

namespace Amelia.Domain.Contracts.Repositories
{
    public interface IUserRepository : IEntityBaseRepository<User>
    {
        User Find(string username, string hashedPassword);
    }
}