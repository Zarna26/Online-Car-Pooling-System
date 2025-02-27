using Microsoft.AspNetCore.Mvc;
using CarpoolingSystem.Models;
using CarpoolingSystem.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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
        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == Email);

            if (user == null || user.PasswordHash != HashPassword(Password))
            {
                ViewData["ErrorMessage"] = "Invalid email or password!";
                return View();
            }

            // ✅ Store success message in TempData
            TempData["SuccessMessage"] = "Login successful! Welcome to GoMate.";

            return RedirectToAction("Index", "Home");
        }

    }
}
