using NUnit.Framework;
using Amelia.WebApp.Controllers;
using Moq;
using Amelia.Domain.Contracts.Services;
using Amelia.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Amelia.WebApp.Models;
using System.Net;
using Amelia.WebApp.ViewModels;

namespace Amelia.Tests.WebApp.Controllers
{
    [TestFixture]
    public class ProjectsControllerTests
    {
        private Mock<IProjectService> _projectServiceMock = new Mock<IProjectService>();
        private Mock<IUserService> _userServiceMock = new Mock<IUserService>();
        private Mock<IAuthorizationService> _authServiceMock = new Mock<IAuthorizationService>();
        private Mock<ILoggingService> _loggingServiceMock = new Mock<ILoggingService>();

        private ProjectsController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new ProjectsController(
                   _projectServiceMock.Object,
                   _userServiceMock.Object,
                   _authServiceMock.Object,
                   _loggingServiceMock.Object);
        }

        [Test]
        public void GetBySlugReturnsAProject()
        {
            var slug = "project-one";
            var project = new Project()
            {
                Id = 2132,
                Name = "Project Name",
                Slug = "project-one",
            };

            _projectServiceMock.Setup(x => x.Find(slug)).Returns(project);

            var actionResult = _controller.GetBySlug(slug) as OkObjectResult;
            var returnProject = actionResult.Value as ProjectViewModel;

            Assert.IsTrue(actionResult.StatusCode == (int)HttpStatusCode.OK);
            Assert.IsTrue(returnProject.Slug.Equals(slug));
        }

        [Test]
        public void GetBySlugReturnsFailureResult()
        {
            var slug = "not-existing-project";
            _projectServiceMock.Setup(x => x.Find(slug)).Returns<Project>(null);

            var actionResult = _controller.GetBySlug(slug) as ObjectResult;
            var genericResult = actionResult.Value as GenericResult;

            Assert.IsFalse(genericResult.Succeeded);
        }

        [Test]
        public void GetByIdReturnsFailureResult()
        {
            var id = 2132;
            _projectServiceMock.Setup(x => x.FindById(id)).Returns<Project>(null);

            var actionResult = _controller.GetById(id) as ObjectResult;
            var genericResult = actionResult.Value as GenericResult;

            Assert.IsFalse(genericResult.Succeeded);
        }
    }
}