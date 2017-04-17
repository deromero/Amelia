using System.Collections.Generic;
using Amelia.Domain.Common;
using Amelia.Domain.Models;

namespace Amelia.Domain.Contracts.Services
{
    public interface ISprintService
    {
        IEnumerable<Sprint> Get(int projectId);
        IEnumerable<Sprint> Get();
        Sprint Find(int sprintId);
        ActionConfirmation Create(Sprint sprint);
        ActionConfirmation Update(Sprint sprint);
        ActionConfirmation Delete(int sprintId);
    }
}