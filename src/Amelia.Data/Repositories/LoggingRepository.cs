using Amelia.Data.Contexts;
using Amelia.Domain.Contracts.Repositories;
using Amelia.Domain.Models;

namespace Amelia.Data.Repositories
{
    public class LoggingRepository : EntityBaseRepository<Error>, ILoggingRepository
    {
        public LoggingRepository(AmeliaContext context) : base(context)
        {
        }

        public override void Commit()
        {
            try { base.Commit(); } catch { }
        }

    }
}