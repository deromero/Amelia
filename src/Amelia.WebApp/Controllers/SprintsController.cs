using Microsoft.AspNetCore.Mvc;
using Amelia.Domain.Contracts.Services;

namespace Amelia.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class SprintsController : AmeliaBaseController
    {
        private readonly ISprintService _sprintService;
    }
}