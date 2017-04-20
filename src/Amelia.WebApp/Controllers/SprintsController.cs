using Microsoft.AspNetCore.Mvc;
using Amelia.Domain.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Amelia.Services;
using System.Threading.Tasks;
using Amelia.WebApp.Models;
using Amelia.Domain.Models;
using Amelia.WebApp.ViewModels;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using System;

namespace Amelia.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class SprintsController : AmeliaBaseController
    {
        private readonly ISprintService _sprintService;
        private readonly IUserService _userService;
        private readonly IAuthorizationService _authorizationService;
        private readonly ILoggingService _loggingService;

        public SprintsController(
            ISprintService sprintService,
            UserService userService,
            IAuthorizationService authorizacionService,
            ILoggingService loggingService)
        {

            _sprintService = sprintService;
            _userService = userService;
            _authorizationService = authorizacionService;
            _loggingService = loggingService;
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("{projectId:int}/{page:int=0}/{pageSize:int=12}")]
        public async Task<IActionResult> Get(int projectId, int? page, int? pageSize)
        {
            var pagedSet = new PaginationSet<SprintViewModel>();
            try
            {
                if (await _authorizationService.AuthorizeAsync(User, "AdminOnly"))
                {
                    var currentPage = page.Value;
                    var currentPageSize = pageSize.Value;

                    var sprints = _sprintService.Get(projectId)
                    .Skip(currentPage * currentPageSize)
                    .Take(currentPageSize)
                    .ToList();

                    var totalSprints = _sprintService.Get(projectId).Count();
                    var sprintViewModels = Mapper.Map<IEnumerable<Sprint>, IEnumerable<SprintViewModel>>(sprints);

                    pagedSet = new PaginationSet<SprintViewModel>(){
                        Page = currentPage,
                        TotalCount = totalSprints,
                        TotalPages = (int)Math.Ceiling((decimal)totalSprints/currentPageSize),
                        Items = sprintViewModels
                    };
                }
                else
                {
                    var codeResult = new CodeResultStatus(401);
                    return new ObjectResult(codeResult);
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