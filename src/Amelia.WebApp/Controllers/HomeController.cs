using Microsoft.AspNetCore.Mvc;

namespace Amelia.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(){
            return  View();
        }
    }
}