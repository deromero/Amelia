using System.Security.Principal;
using Amelia.Domain.Models;

namespace Amelia.WebApp.Models
{
    public class MembershipContext
    {
        public IPrincipal Principal{get;set;}
        public User User{get;set;}
        public bool IsValid(){
            return Principal !=null;
        }
    }
}