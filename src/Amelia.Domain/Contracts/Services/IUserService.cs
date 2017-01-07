using System.Collections.Generic;
using Amelia.Domain.Models;

namespace Amelia.Domain.Contracts.Services
{
    public interface IUserService
    {
        User Find(string username);
        User Find(string username, string hashedPassword);
        int TotalCount { get; }
        IEnumerable<User> GetAll();
        User FindById(int id);
        void Create(User user);
        IEnumerable<Role> GetUserRoles(string username);
        void AddUserToRole(User user, int role);
    }
}