using System;
using System.Linq;
using Amelia.WebApi.Data;
using Amelia.WebApi.Models.Contracts.Repositories;
using Amelia.WebApi.Models.Entities;

namespace Amelia.Data.Repositories
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(AmeliaContext context) : base(context)
        {
        }

        public User Find(string username, string hashedPassword)
        {
            return FindBy(u=>u.Username == username && u.Password == hashedPassword).SingleOrDefault();
        }
    }
}