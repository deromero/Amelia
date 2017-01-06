using Amelia.Data.Contexts;
using Amelia.Domain.Contracts.Repositories;
using Amelia.Domain.Models;

namespace Amelia.Data.Repositories
{
    public class RoleRepository : EntityBaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(AmeliaContext context) : base(context) { }

    }
}