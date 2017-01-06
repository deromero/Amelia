using Amelia.Data.Contexts;
using Amelia.Domain.Contracts.Repositories;
using Amelia.Domain.Models;

namespace Amelia.Data.Repositories
{
    public class ProjectRepository : EntityBaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AmeliaContext context) : base(context) { }


        
    }
}