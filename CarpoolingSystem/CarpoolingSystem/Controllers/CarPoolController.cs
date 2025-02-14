using Microsoft.AspNetCore.Mvc;

namespace CarpoolingSystem.Controllers
{
    public class CarPoolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
