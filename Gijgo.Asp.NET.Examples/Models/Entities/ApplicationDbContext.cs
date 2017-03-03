using System.Data.Entity;

namespace Gijgo.Asp.NET.Examples.Models.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection") { }

        public ApplicationDbContext(string connStr) : base(connStr) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerTeam> PlayerTeams { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}