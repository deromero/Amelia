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
    public class ProjectsController : AmeliaBaseController
    {
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;
        private readonly IAuthorizationService _authorizationService;
        private readonly ILoggingService _loggingService;

        public ProjectsController(
                            IProjectService projectService,
                            IUserService userService,
                            IAuthorizationService authorizacionService,
                            ILoggingService loggingService)
        {
            _projectService = projectService;
            _userService = userService;
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

                    foreach (var item in projectViewModels)
                    {
                        item.IssueCount = projects.Single(x=>x.Id == item.Id).Tasks.Count();
                    }


                    pagedSet = new PaginationSet<ProjectViewModel>()
                    {
                        Page = currentPage,
                        TotalCount = totalProjects,
                        TotalPages = (int)Math.Ceiling((decimal)totalProjects / currentPageSize),
                        Items = projectViewModels
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

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.FindById(id);
            if (project == null)
            {
                return new ObjectResult(GenericResult.Failure("Project does not exist"));
            }

            var viewModel = Mapper.Map<Project, ProjectViewModel>(project);
            return new OkObjectResult(viewModel);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("get/{slug}")]
        public IActionResult GetBySlug(string slug)
        {
            var project = _projectService.Find(slug);
            if (project == null)
            {
                return new ObjectResult(GenericResult.Failure("Project does not exist"));
            }

            var viewModel = Mapper.Map<Project, ProjectViewModel>(project);
            return new OkObjectResult(viewModel);
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] NewProjectFormModel formModel)
        {
            var result = new ObjectResult(false);
            GenericResult newProjectResult = null;

            try
            {
                if (ModelState.IsValid)
                {
                    var project = new Project
                    {
                        Name = formModel.Name.TrimEnd(),
                        Description = formModel.Description,
                        ProjectType = formModel.ProjectType,
                        IsPrivate = formModel.IsPrivate,
                        Owner = _userService.Find(User.Identity.Name),
                    };

                    var confirmation = _projectService.Create(project);

                    if (confirmation.WasSuccessful)
                    {
                        newProjectResult = GenericResult.Ok(confirmation.Message);
                        var newProject = confirmation.Value as Project;
                        newProjectResult.ReturnValue = new
                        {
                            Id = newProject.Id,
                            Slug = newProject.Slug
                        };
                    }
                    else
                    {
                        newProjectResult = GenericResult.Failure(confirmation.Message);
                    }
                }
            }
            catch (System.Exception exception)
            {
                newProjectResult = GenericResult.Failure(exception.Message);
                _loggingService.Add(Error.FromException(exception));
            }

            result = new ObjectResult(newProjectResult);
            return result;
        }

    }
}