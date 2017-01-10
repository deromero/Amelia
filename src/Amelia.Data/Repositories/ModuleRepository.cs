using Amelia.Data.Contexts;
using Amelia.Domain.Contracts.Repositories;
using Amelia.Domain.Models;

namespace Amelia.Data.Repositories
{
    public class ModuleRepository : EntityBaseRepository<Module>, IModuleRepository
    {
        public ModuleRepository(AmeliaContext context) : base(context)
        {
        }
    }
}