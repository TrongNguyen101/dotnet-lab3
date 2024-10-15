using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.DataContext
{
    public class StoreContext : DbContext
    {
        public StoreContext() { }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Override method OnConfiguration to create conenction to database
        /// This method will read json file name appsetings.json to read connection string
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) // If optionBuider didn't configured method will create configuration
            {
                IConfigurationRoot configuration = new ConfigurationBuilder() // Create new configuration
                   .SetBasePath(Directory.GetCurrentDirectory()) // Set base path of directory to use file appsettings.json
                   .AddJsonFile("appsettings.json")             // Add json file name appsettings to directory
                   .Build();                                   // Build directory
                var connectionString = configuration.GetConnectionString("TrongConnection"); // Read connection string in json file name appsetings.json
                optionsBuilder.UseSqlServer(connectionString);  // Use Sql Server provider to connect into the database
            }
        }

        /// <summary>
        /// Override method OnModelCreating to create entity in database
        /// This method will create entity using FluentAPI and add value in to the database
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Beverages" },
                new Category { CategoryId = 2, CategoryName = "Condiments" },
                new Category { CategoryId = 3, CategoryName = "Confections" },
                new Category { CategoryId = 4, CategoryName = "Dairy Products" },
                new Category { CategoryId = 5, CategoryName = "Grains/Cereals" },
                new Category { CategoryId = 6, CategoryName = "Meat/Poultry" },
                new Category { CategoryId = 7, CategoryName = "Produce" },
                new Category { CategoryId = 8, CategoryName = "Seafood" }
            );
        }
    }
}