using Microsoft.AspNetCore.Mvc;

[Route("Admin/Home")]
public class Admin_HomeController : Controller
{
    [Route("Index")]
    public IActionResult Index()
    {
        return View("~/Views/Admin/Home/Index.cshtml");
    }
}
