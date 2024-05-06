using Microsoft.EntityFrameworkCore;

namespace Cars.Models
{
    public class CarDBContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        

        public CarDBContext(DbContextOptions<CarDBContext> options) : base(options)
        {
        }

    }
}
