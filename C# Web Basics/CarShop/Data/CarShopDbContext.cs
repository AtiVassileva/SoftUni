﻿using CarShop.Data.Models;

namespace CarShop.Data
{
    using Microsoft.EntityFrameworkCore;
    public class CarShopDbContext : DbContext
    {
        public CarShopDbContext()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Issue> Issues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=CarShop;Integrated Security=true");
            }
        }
    }
}
