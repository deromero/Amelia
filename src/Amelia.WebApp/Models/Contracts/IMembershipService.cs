using Amelia.Domain.Models;

namespace Amelia.WebApp.Models.Contracts
{
    public interface IMembershipService
    {
        MembershipContext ValidateUser(string username, string password);
        User CreateUser(string username, string email, string password, int[] roles);
        User GetUser(int userId);
    }
}