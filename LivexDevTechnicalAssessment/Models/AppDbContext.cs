﻿using Microsoft.EntityFrameworkCore;

namespace LivexDevTechnicalAssessment.Models
{
    //Serves as the bridge between the code and the cloud database.
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> ConnectionOptions) : base(ConnectionOptions)
        {
        }
        public DbSet<Inventory> InventoryItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }

        /*
        I wanted the model to have some data upon creation so that 
        I have something to work with for testing purposes
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { Id = 1, Name = "Marvel Comic", Price = 149.99, Quantity = 10 },
                new Inventory { Id = 2, Name = "Bible", Price = 89.99, Quantity = 5 },
                new Inventory { Id = 3, Name = "One Piece", Price = 49.99, Quantity = 2 }

            );

            //Set the default quantity to 1 in case it is not given
            modelBuilder.Entity<Inventory>().Property("Quantity").HasDefaultValue(1);

        }

    }

}
