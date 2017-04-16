using Amelia.Data.Contexts;
using Amelia.Domain.Contracts.Repositories;
using Amelia.Domain.Models;

namespace Amelia.Data.Repositories
{
    public class TaskRepository : EntityBaseRepository<Task>, ITaskRepository
    {
        public TaskRepository(AmeliaContext context ): base(context){ }
    }
}