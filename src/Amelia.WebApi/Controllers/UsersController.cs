using System;
using System.Collections.Generic;
using System.Linq;
using Amelia.WebApi.Core;
using Amelia.WebApi.Models.Contracts.Repositories;
using Amelia.WebApi.Models.Entities;
using Amelia.WebApi.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Amelia.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserRepository _userRepository;

        int _page = 1;
        int _pageSize = 10;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Get()
        {
            var pagination = Request.Headers["Pagination"];
            if (!string.IsNullOrEmpty(pagination))
            {
                var values = pagination.ToString().Split(',');
                int.TryParse(values[0], out _page);
                int.TryParse(values[1], out _pageSize);
            }

            int currentPage = _page;
            int currentPageSize = _pageSize;

            var totalUsers = _userRepository.Count();
            var totalPages = (int)Math.Ceiling((double)totalUsers / _pageSize);

            IEnumerable<User> users = _userRepository
                    .GetAll()
                    .OrderBy(u => u.Id)
                    .Skip((currentPage - 1) * currentPageSize)
                    .Take(currentPageSize)
                    .ToList();

            IEnumerable<UserViewModel> usersVm = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
            Response.AddPagination(_page, _pageSize, totalUsers, totalPages);

            return new OkObjectResult(usersVm);
        }


        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(int id)
        {
            User user = _userRepository.GetSingle(u => u.Id == id);

            if (user != null)
            {
                var userVm = Mapper.Map<User, UserViewModel>(user);
                return new OkObjectResult(userVm);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = new User
            {
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            _userRepository.Add(newUser);
            _userRepository.Commit();

            user = Mapper.Map<User, UserViewModel>(newUser);

            CreatedAtRouteResult result = CreatedAtRoute("GetUser", new
            {
                controller = "Users",
                id = user.Id
            }, user);
            return result;
        }

    }
}