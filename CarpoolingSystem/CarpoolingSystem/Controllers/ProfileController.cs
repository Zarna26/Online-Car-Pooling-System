using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using CarpoolingSystem.Data;  // Make sure you import your DbContext
using CarpoolingSystem.Models;
using System.Security.Claims;

namespace CarpoolingSystem.Controllers
{
    [Authorize] // Ensure only logged-in users can access this page
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Get the logged-in user's email
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            if (userEmail == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Fetch user details from database
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

            if (user == null)
            {
                return NotFound("User not found!");
            }

            return View(user); // Pass user data to view
        }
    }
}
