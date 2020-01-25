using Microsoft.EntityFrameworkCore;

namespace PimpMyRide.Domain.SQLStorage
{
    public class PimpMyRideContext : DbContext
    {
        public DbSet<CarModel>? Cars { get; set; }
        public DbSet<PartModel>? Parts { get; set; }

        public PimpMyRideContext() : base(new DbContextOptionsBuilder<PimpMyRideContext>()
            .UseSqlServer("Server=localhost;Database=PimpMyRide;Trusted_Connection=True;")
            .Options)
        {
        }
    }
}