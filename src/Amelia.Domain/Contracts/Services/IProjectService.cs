using System.Collections.Generic;
using Amelia.Domain.Common;
using Amelia.Domain.Models;

namespace Amelia.Domain.Contracts.Services
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAll();
        ActionConfirmation Create(Project project);
        Project FindById(int projectId);
        Project Find(string projectSlug);
    }
}