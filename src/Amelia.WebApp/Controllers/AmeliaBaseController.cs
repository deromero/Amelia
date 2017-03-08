using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amelia.WebApp.Controllers
{
    [Authorize]
    public class AmeliaBaseController : Controller
    {
        
    }
}