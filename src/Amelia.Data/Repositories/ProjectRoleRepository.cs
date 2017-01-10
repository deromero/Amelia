using Amelia.Data.Contexts;
using Amelia.Domain.Contracts.Repositories;
using Amelia.Domain.Models;

namespace Amelia.Data.Repositories
{
    public class ProjectRoleRepository : EntityBaseRepository<ProjectRole>, IProjectRoleRepository
    {
        public ProjectRoleRepository(AmeliaContext context) : base(context)
        {
        }
    }
}