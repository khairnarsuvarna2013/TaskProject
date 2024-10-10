using Microsoft.EntityFrameworkCore;
using TaskProject.Client.Models;

namespace TaskProject.Data
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; } // Replace City with your model
        public DbSet<Weather> Weather { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Weather>()
                   .HasKey(w => w.WId); // Defines WId as the primary key
                                         }
        }
}
