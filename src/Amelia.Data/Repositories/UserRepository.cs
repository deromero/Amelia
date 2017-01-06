using System.Collections.Generic;
using System.Linq;
using Amelia.Data.Contexts;
using Amelia.Domain.Contracts.Repositories;
using Amelia.Domain.Models;

namespace Amelia.Data.Repositories
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(AmeliaContext context) : base(context) { }

        public User Find(string username, string hashedPassword)
        {
            return FindBy(
                u => u.Username == username &&
                u.Password == hashedPassword
                ).SingleOrDefault();
        }
    }
}