using Amelia.Domain.Contracts.Repositories;
using Amelia.Domain.Contracts.Services;

namespace Amelia.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRespository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRespository = projectRepository;
        }
    }
}