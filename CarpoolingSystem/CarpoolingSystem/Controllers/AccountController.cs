using Microsoft.AspNetCore.Mvc;
using CarpoolingSystem.Models;
using CarpoolingSystem.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace CarpoolingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model, string ConfirmPassword)
        {
            if (ModelState.IsValid)
            {
                // Check if passwords match
                if (model.PasswordHash != ConfirmPassword)
                {
                    ViewData["ErrorMessage"] = "Passwords do not match!";
                    return View();
                }

                // Check if Email already exists
                if (_context.Users.Any(u => u.Email == model.Email))
                {
                    ViewData["ErrorMessage"] = "Email is already registered!";
                    return View();
                }

                // Hash Password before storing
                model.PasswordHash = HashPassword(model.PasswordHash);

                // Add User to Database
                _context.Users.Add(model);
                _context.SaveChanges();

                ViewData["SuccessMessage"] = "Registration successful! You can now login.";
                return RedirectToAction("Login");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }



        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == Email);

            if (user == null || user.PasswordHash != HashPassword(Password))
            {
                ViewData["ErrorMessage"] = "Invalid email or password!";
                return View();
            }

            // ✅ Create user claims
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.FirstName),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) // Important for authentication
    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true // Keep the user logged in
            };

            // ✅ Sign in the user
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            // ✅ Store success message in TempData
            TempData["SuccessMessage"] = "Login successful! Welcome to Carpooling System.";

            return RedirectToAction("Index", "Home");
        }

    }
}
