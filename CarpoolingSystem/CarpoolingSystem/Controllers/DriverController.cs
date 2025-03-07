using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CarpoolingSystem.Data;
using CarpoolingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CarpoolingSystem.Controllers
{
    [Authorize] // Ensures only logged-in users can access this controller
    public class DriverController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DriverController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult MyRides()
        {
            string driverId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

            if (string.IsNullOrEmpty(driverId))
            {
                return Unauthorized(); // If user is not logged in
            }

            var rides = _context.Rides.Where(r => r.DriverId == driverId).ToList();
            return View(rides);
        }

        public IActionResult PostRide()
        {
            return View(new Ride()); // Pass an empty Ride object to the view
        }

        [HttpPost]
        public IActionResult PostRide(Ride ride)
        {
            string driverId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

            if (string.IsNullOrEmpty(driverId))
            {
                Console.WriteLine("DriverId not found."); // Log for debugging
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ride.DriverId = driverId;
                    _context.Rides.Add(ride);
                    _context.SaveChanges();
                    Console.WriteLine("Ride successfully saved! Redirecting to MyRides.");
                    return RedirectToAction("MyRides");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    ModelState.AddModelError("", "An error occurred while saving the ride.");
                }
            }
            else
            {
                Console.WriteLine("Model state is invalid.");
            }

            return View(ride); // Redisplay the form if validation fails
        }

    }
}
