using System;
using System.Linq;
using System.Security.Principal;
using Amelia.Domain.Contracts.Services;
using Amelia.Domain.Enums;
using Amelia.Domain.Models;
using Amelia.WebApp.Models.Contracts;

namespace Amelia.WebApp.Models.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IUserService _userService;
        private readonly IEncryptionService _encryptionService;

        public MembershipService(IUserService userService, IEncryptionService encryptionService)
        {
            _userService = userService;
            _encryptionService = encryptionService;
        }

        public MembershipContext ValidateUser(string username, string password)
        {
            var membershipContext = new MembershipContext();
            var user = _userService.Find(username);
            if (user != null && IsUserValid(user, password))
            {
                membershipContext.User = user;
                var userRoles = _userService.GetUserRoles(user.Username);

                var identity = new GenericIdentity(user.Username);
                membershipContext.Principal = new GenericPrincipal(
                    identity,
                    userRoles.Select(x => x.Name).ToArray());
            }

            return membershipContext;
        }

        public User CreateUser(string username, string email, string password, int[] roles)
        {
            var existingUser = _userService.Find(username);
            if (existingUser != null)
            {
                throw new Exception("Username is already in use");
            }

            var passwordSalt = _encryptionService.CreateSalt();

            var newUser = new User()
            {
                Username = username,
                Salt = passwordSalt,
                Email = email,
                Password = _encryptionService.EncryptPassword(password, passwordSalt),
                CreatedOn = DateTime.Now
            };

            _userService.Create(newUser);

            if (roles != null || roles.Length >0)
            {
                foreach(var role in roles){
                    _userService.AddUserToRole(newUser, role);
                }
            }

            return newUser;
        }


        public User GetUser(int userId)
        {
            return _userService.FindById(userId);
        }



        private bool IsPasswordValid(User user, string password)
        {
            return string.Equals(_encryptionService.EncryptPassword(password, user.Salt), user.Password);
        }

        private bool IsUserValid(User user, string password)
        {
            if (IsPasswordValid(user, password))
            {
                return user.Status == (int)UserStatus.Online;
            }

            return false;
        }

       
    }
}