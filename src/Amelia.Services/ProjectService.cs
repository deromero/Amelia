using System;
using System.Collections.Generic;
using Amelia.Domain.Common;
using Amelia.Domain.Contracts.Repositories;
using Amelia.Domain.Contracts.Services;
using Amelia.Domain.Enums;
using Amelia.Domain.Models;

namespace Amelia.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IEnumerable<Project> GetAll()
        {
            return _projectRepository.GetAll();
        }

        public void Create(Project project)
        {
            //Default data before save
            project.Slug = Utilities.RemoveSpacesAndSpecialsChars(project.Name.ToLowerInvariant());
            project.CreatedOn = DateTime.Now;
            project.UpdatedOn = DateTime.Now;
            project.Status = (short)ProjectStatus.Draft;

            _projectRepository.Add(project);
            _projectRepository.Commit();
        }

        public Project FindById(int projectId)
        {
            return _projectRepository.GetSingle(projectId);
        }

        public Project Find(string projectSlug)
        {
            return _projectRepository.GetSingle(p => p.Slug == projectSlug);
        }
    }
}