using Microsoft.EntityFrameworkCore;

namespace PimpMyRide.Domain.SQLStorage
{
    public class PimpMyRideContext : DbContext
    {
        public DbSet<CarModel>? Cars { get; set; }
        public DbSet<PartModel>? Parts { get; set; }
        public DbSet<PlayerModel>? Players { get; set; }
        public DbSet<GameModel>? Games { get; set; }

        public PimpMyRideContext() : base(new DbContextOptionsBuilder<PimpMyRideContext>()
            .UseSqlServer("Server=localhost;Database=PimpMyRide;Trusted_Connection=True;")
            .Options)
        {
        }
    }
}