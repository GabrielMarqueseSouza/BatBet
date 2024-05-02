using BatBetDomain.Entities;
using BatBetInfrastructure.Data.Mappings;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace BatBetInfrastructure.Data
{
    public sealed class BatBetDbContext(DbContextOptions<BatBetDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntitiesMapping).Assembly);
        }

        public DbSet<AvailableBet> AvailableBets { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
