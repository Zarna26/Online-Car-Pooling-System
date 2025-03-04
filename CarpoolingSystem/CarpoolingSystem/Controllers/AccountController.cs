using Microsoft.AspNetCore.Mvc;
using CarpoolingSystem.Models;
using CarpoolingSystem.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

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
                if (model.PasswordHash != ConfirmPassword)
                {
                    ViewData["ErrorMessage"] = "Passwords do not match!";
                    return View();
                }

                if (_context.Users.Any(u => u.Email == model.Email))
                {
                    ViewData["ErrorMessage"] = "Email is already registered!";
                    return View();
                }

                if (string.IsNullOrEmpty(model.UserType))
                {
                    ViewData["ErrorMessage"] = "Please select whether you are a Passenger or a Driver.";
                    return View();
                }

                model.PasswordHash = HashPassword(model.PasswordHash);

                _context.Users.Add(model);
                _context.SaveChanges();

                ViewData["SuccessMessage"] = "Registration successful! You can now login.";
                return RedirectToAction("Login");
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Password, string UserType)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == Email && u.UserType == UserType);

            if (user == null || user.PasswordHash != HashPassword(Password))
            {
                ViewData["ErrorMessage"] = "Invalid email, password, or user type!";
                return View();
            }

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.FirstName),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim("UserType", user.UserType)
    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties { IsPersistent = true };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            TempData["SuccessMessage"] = "Login successful!";

            if (user.UserType == "Driver")
            {
                return RedirectToAction("Index", "Admin_Home");
            }
            else if (user.UserType == "Passenger")
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
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
    }
}
