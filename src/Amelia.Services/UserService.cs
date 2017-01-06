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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

        public User FindById(int id)
        {
            return _userRepository.FindBy(u=>u.Id == id).SingleOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}