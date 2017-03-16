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
        private IProjectRoleRepository _projectRoleRepository;

        public ProjectService(
            IProjectRepository projectRepository,
            IProjectRoleRepository projectRoleRepository)
        {
            _projectRepository = projectRepository;
            _projectRoleRepository = projectRoleRepository;
        }

        public IEnumerable<Project> GetAll()
        {
            return _projectRepository.GetAll();
        }

        public ActionConfirmation Create(Project project)
        {
            try
            {
                //Default data before save
                project.Slug = Utilities.RemoveSpacesAndSpecialsChars(project.Name.ToLowerInvariant());
                project.CreatedOn = DateTime.Now;
                project.UpdatedOn = DateTime.Now;
                project.Status = (short)ProjectStatus.Draft;
                _projectRepository.Add(project);
                _projectRepository.Commit();

                

                if(project.Owner != null){
                    
                }


                var confirmation = ActionConfirmation.CreateSuccess(project.Name + " Created");
                confirmation.Value = project;

                return confirmation;
            }
            catch (System.Exception exception)
            {
                return ActionConfirmation.CreateFailure(exception.Message);
            }
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