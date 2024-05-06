using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WeatherInformation.Dto;

namespace WeatherInformation.Models
{
    public class WeatherInfoDbContext : DbContext
    {
        public DbSet<WeatherInfo> WeatherInfos { get; set; }
        

        public WeatherInfoDbContext(DbContextOptions<WeatherInfoDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherInfo>()
                .HasKey(w => new { w.city, w.datetime });
        }

    }
}
