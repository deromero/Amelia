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
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IAuthorizationService _authorizationService;
        private readonly ILoggingService _loggingService;

        public ProjectsController(
                            IProjectService projectService,
                            IAuthorizationService authorizacionService,
                            ILoggingService loggingService)
        {
            _projectService = projectService;
            _authorizationService = authorizacionService;
            _loggingService = loggingService;
        }


        [Authorize(Policy = "AdminOnly")]
        [HttpGet("{page:int=0}/{pageSize=12}")]
        public async Task<IActionResult> Get(int? page, int? pageSize)
        {
            var pagedSet = new PaginationSet<ProjectViewModel>();
            try
            {
                if (await _authorizationService.AuthorizeAsync(User, "AdminOnly"))
                {
                    var currentPage = page.Value;
                    var currentPageSize = pageSize.Value;

                    var projects = _projectService.GetAll()
                    .OrderBy(p => p.Id)
                    .Skip(currentPage * currentPageSize)
                    .Take(currentPageSize)
                    .ToList();

                    var totalProjects = _projectService.GetAll().Count();
                    var projectViewModels = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projects);

                    pagedSet = new PaginationSet<ProjectViewModel>()
                    {
                        Page = currentPage,
                        TotalCount = totalProjects,
                        TotalPages = (int)Math.Ceiling((decimal)totalProjects / currentPageSize),
                        Items = projectViewModels
                    };
                }else{
                    var _codeResult = new CodeResultStatus(401);
                    return new ObjectResult(_codeResult);
                }
            }
            catch (System.Exception exception)
            {
                _loggingService.Add(new Error()
                {
                    Message = exception.Message,
                    StackTrace = exception.StackTrace,
                    DateCreated = DateTime.Now
                });
            }

            return new ObjectResult(pagedSet);
        }

    }
}