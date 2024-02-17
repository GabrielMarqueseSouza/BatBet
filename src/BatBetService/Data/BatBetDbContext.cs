using BatBetService.Data.Mappings;
using BatBetService.Entities;
using Microsoft.EntityFrameworkCore;

namespace BatBetService.Data
{
    public class BatBetDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntitiesMapping).Assembly);
        }

        public DbSet<AvailableBet> AvailableBets { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
