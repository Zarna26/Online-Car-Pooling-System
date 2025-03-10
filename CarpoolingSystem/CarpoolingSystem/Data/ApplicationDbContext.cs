﻿using Microsoft.EntityFrameworkCore;
using CarpoolingSystem.Models;

namespace CarpoolingSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Ride> Rides { get; set; }

    }
}
