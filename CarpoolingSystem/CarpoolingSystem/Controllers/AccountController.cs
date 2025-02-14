using Microsoft.AspNetCore.Mvc;

namespace CarpoolingSystem.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Handle login logic here (e.g., validate email/password)
            // For now, just a simple redirect for demonstration purposes.
            return RedirectToAction("Index", "Home"); // Redirect to the Home page after login
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string fullName, string email, string password, string confirmPassword)
        {
            // Check if passwords match
            if (password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match!";
                return View();
            }

            // Here, you would normally save the user data to the database
            // For now, we'll just redirect to the login page after registration
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            // Clear authentication session (if using Identity, change this logic)
            return RedirectToAction("Index", "Home");
        }
    }
}
