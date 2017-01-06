using Amelia.Data.Contexts;
using Amelia.Domain.Contracts.Repositories;
using Amelia.Domain.Models;

namespace Amelia.Data.Repositories
{
    public class UserRoleRepository : EntityBaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(AmeliaContext context) : base(context) { }

    }
}