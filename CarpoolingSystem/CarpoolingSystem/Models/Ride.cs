using System;
using System.ComponentModel.DataAnnotations;

namespace CarpoolingSystem.Models
{
    public class Ride
    {
        [Key]
        public string RideId { get; set; } // Unique identifier for the ride

        [Required]
        public string DriverId { get; set; } // ID of the driver posting the ride

        [Required]
        public string PickupLocation { get; set; } // Starting point

        [Required]
        public string DropoffLocation { get; set; } // Destination

        [Required]
        public DateTime RideDate { get; set; } // Date and time of the ride

        [Required]
        public decimal Price { get; set; } // Cost of the ride

        public int AvailableSeats { get; set; } // Number of available seats
    }
}
