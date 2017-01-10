using Amelia.Data.Contexts;
using Amelia.Domain.Contracts.Repositories;
using Amelia.Domain.Models;

namespace Amelia.Data.Repositories
{
    public class MemberRepository : EntityBaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(AmeliaContext context) : base(context)
        {
        }
    }
}