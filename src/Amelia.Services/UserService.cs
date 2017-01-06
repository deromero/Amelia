using System;
using System.Collections.Generic;
using System.Linq;
using Amelia.Domain.Contracts.Repositories;
using Amelia.Domain.Contracts.Services;
using Amelia.Domain.Models;

namespace Amelia.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;


        public UserService(
            IUserRepository userRepository, 
            IRoleRepository roleRepository, 
            IUserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
        }

        public int TotalCount
        {
            get
            {
                return _userRepository.Count();
            }
        }

        public void Create(User user)
        {
            _userRepository.Add(user);
            _userRepository.Commit();
        }

        public User Find(string username, string hashedPassword)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException(nameof(username));
            if (string.IsNullOrEmpty(hashedPassword)) throw new ArgumentNullException(nameof(hashedPassword));

            return _userRepository.Find(username, hashedPassword);
        }

        public User Find(string username)
        {
            return _userRepository.FindBy(u => u.Username == username).SingleOrDefault();
        }

        public User FindById(int id)
        {
            return _userRepository.FindBy(u => u.Id == id).SingleOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public IEnumerable<Role> GetUserRoles(string username)
        {
            List<Role> _roles = null;
 
            User _user = _userRepository.GetSingle(u => u.Username == username, u => u.UserRoles);
            if(_user != null)
            {
                _roles = new List<Role>();
                foreach (var _userRole in _user.UserRoles)
                    _roles.Add(_roleRepository.GetSingle(_userRole.RoleId));
            }
 
            return _roles;
        }

        public void AddUserToRole(User user, int roleId)
        {
            var role = _roleRepository.GetSingle(roleId);
            if(role!=null) throw new Exception("Role doesn't exist");

            var userRole = new UserRole(){
                RoleId = role.Id,
                UserId = user.Id
            };

            _userRoleRepository.Add(userRole);
            _userRepository.Commit();

        }
    }
}