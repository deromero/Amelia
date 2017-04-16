using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amelia.Domain.Contracts.Services;
using Amelia.Domain.Models;
using Amelia.WebApp.Models;
using Amelia.WebApp.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amelia.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : AmeliaBaseController
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;
        private readonly IAuthorizationService _authorizationService;
        private readonly ILoggingService _loggingService;
        public TasksController(
            ITaskService taskService,
            IUserService userService,
            IAuthorizationService authorizacionService,
            ILoggingService loggingService
            )
        {
            _taskService = taskService;
            _userService = userService;
            _authorizationService = authorizacionService;
            _loggingService = loggingService;
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("{projectId:int}/{page:int=0}/{pageSize:int=12}")]
        public async Task<IActionResult> Get(int projectId, int? page, int? pageSize)
        {
            var pagedSet = new PaginationSet<TaskViewModel>();
            try
            {
                if (await _authorizationService.AuthorizeAsync(User, "AdminOnly"))
                {
                    var currentPage = page.Value;
                    var currentPageSize = pageSize.Value;

                    var tasks = _taskService.GetList(projectId)
                    .Skip(currentPage * currentPageSize)
                    .Take(currentPageSize)
                    .ToList();

                    var totalTasks = _taskService.GetList(projectId).Count();
                    var taskViewModels = Mapper.Map<IEnumerable<Amelia.Domain.Models.Task>, IEnumerable<TaskViewModel>>(tasks);

                    pagedSet = new PaginationSet<TaskViewModel>()
                    {
                        Page = currentPage,
                        TotalCount = totalTasks,
                        TotalPages = (int)Math.Ceiling((decimal)totalTasks / currentPageSize),
                        Items = taskViewModels
                    };
                }
                else
                {
                    var _codeResult = new CodeResultStatus(401);
                    return new ObjectResult(_codeResult);
                }
            }
            catch (System.Exception exception)
            {
                _loggingService.Add(Error.FromException(exception));
            }

            return new OkObjectResult(pagedSet);
        }

    }
}