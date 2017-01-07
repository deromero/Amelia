using System.Collections.Generic;
using Amelia.Domain.Models;

namespace Amelia.Domain.Contracts.Services
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAll();
        void Create(Project project);

        Project FindById(int projectId);
        Project Find(string projectSlug);
    }
}