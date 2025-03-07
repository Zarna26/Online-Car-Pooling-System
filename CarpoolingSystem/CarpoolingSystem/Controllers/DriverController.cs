using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CarpoolingSystem.Data;
using CarpoolingSystem.Models;

namespace CarpoolingSystem.Controllers
{
    public class DriverController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DriverController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult MyRides()
        {
            string driverId = "1"; // Replace with actual session user ID
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
            if (ModelState.IsValid)
            {
                _context.Rides.Add(ride);
                _context.SaveChanges();
                return RedirectToAction("MyRides");
            }
            return View(ride);
        }

    }
}