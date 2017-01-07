using System;
using System.Collections.Generic;
using Amelia.Domain.Contracts.Repositories;
using Amelia.Domain.Contracts.Services;
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
    }
}