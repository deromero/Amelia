using System;
using System.Collections.Generic;
using System.Linq;
using Amelia.Domain.Contracts.Repositories;
using Amelia.Domain.Contracts.Services;
using Amelia.Domain.Models;

namespace Amelia.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;


        public TaskService(ITaskRepository taskRepository){
            _taskRepository = taskRepository;
        }

        public IEnumerable<Task> GetList(int projectId)
        {
            return _taskRepository.GetAll()
                    .Where(t=>t.Project.Id == projectId);
        }
    }
}