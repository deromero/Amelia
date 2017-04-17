using System;
using System.Collections.Generic;
using System.Linq;
using Amelia.Domain.Common;
using Amelia.Domain.Contracts.Repositories;
using Amelia.Domain.Contracts.Services;
using Amelia.Domain.Enums;
using Amelia.Domain.Models;

namespace Amelia.Services
{
    public class SprintService : ISprintService
    {
        private readonly ISprintRepository _sprintRepository ;

        public SprintService(ISprintRepository sprintRepository){
            _sprintRepository = sprintRepository;
        }

        public ActionConfirmation Create(Sprint sprint)
        {
            try
            {
                sprint.CreatedOn = DateTime.Now;
                sprint.UpdatedOn = DateTime.Now;

                _sprintRepository.Add(sprint);
                _sprintRepository.Commit();

                var confirmation =ActionConfirmation.CreateSuccess(sprint.Name + " Created");
                confirmation.Value = sprint;

                return confirmation;

            }
            catch (System.Exception exception)
            {
                return ActionConfirmation.CreateFailure(exception.Message);
            }
        }

        public ActionConfirmation Delete(int sprintId)
        {
            throw new NotImplementedException();
        }

        public Sprint Find(int sprintId)
        {
            return _sprintRepository.GetSingle(sprintId);
        }

        public IEnumerable<Sprint> Get(int projectId)
        {
            return _sprintRepository.GetAll()
                .Where(s=>s.Project.Id == projectId);
        }

        public IEnumerable<Sprint> GetAll()
        {
            return _sprintRepository.GetAll();
        }

        public ActionConfirmation Update(Sprint sprint)
        {
            throw new NotImplementedException();
        }
    }
}