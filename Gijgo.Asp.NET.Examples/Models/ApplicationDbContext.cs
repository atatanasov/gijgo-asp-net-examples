using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gijgo.Asp.NET.Examples.Models
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