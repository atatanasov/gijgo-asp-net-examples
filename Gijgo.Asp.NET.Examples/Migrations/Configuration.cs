namespace Gijgo.Asp.NET.Examples.Migrations
{
    using Gijgo.Asp.NET.Examples.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Gijgo.Asp.NET.Examples.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Gijgo.Asp.NET.Examples.Models.ApplicationDbContext context)
        {
            context.Players.AddOrUpdate(
              new Player { ID = 1, Name = "Hristo Stoichkov", PlaceOfBirth = "Plovdiv, Bulgaria", DateOfBirth = new System.DateTime(1966, 02, 08) },
              new Player { ID = 2, Name = "Ronaldo Luís Nazário de Lima", PlaceOfBirth = "Rio de Janeiro, Brazil", DateOfBirth = new System.DateTime(1976, 09, 18) },
              new Player { ID = 3, Name = "David Platt", PlaceOfBirth = "Chadderton, Lancashire, England", DateOfBirth = new System.DateTime(1966, 06, 10) },
              new Player { ID = 4, Name = "Manuel Neuer", PlaceOfBirth = "Gelsenkirchen, West Germany", DateOfBirth = new System.DateTime(1986, 03, 27) },
              new Player { ID = 5, Name = "James Rodríguez", PlaceOfBirth = "Cúcuta, Colombia", DateOfBirth = new System.DateTime(1991, 07, 12) },
              new Player { ID = 6, Name = "Dimitar Berbatov", PlaceOfBirth = "Blagoevgrad, Bulgaria", DateOfBirth = new System.DateTime(1981, 01, 30) },
              new Player { ID = 7, Name = "Robert Lewandowski", PlaceOfBirth = "Warsaw, Poland", DateOfBirth = new System.DateTime(1988, 08, 21) }
            );

            context.PlayerTeams.AddOrUpdate(
                new PlayerTeam { PlayerID = 1, FromYear = 1982, ToYear = 1984, Team = "Hebros Harmanli", Apps = 32, Goals = 14 },
                new PlayerTeam { PlayerID = 1, FromYear = 1984, ToYear = 1990, Team = "CSKA Sofia", Apps = 119, Goals = 81 },
                new PlayerTeam { PlayerID = 1, FromYear = 1990, ToYear = 1995, Team = "Barcelona", Apps = 149, Goals = 77 },
                new PlayerTeam { PlayerID = 1, FromYear = 1995, ToYear = 1996, Team = "Parma", Apps = 23, Goals = 5 },
                new PlayerTeam { PlayerID = 1, FromYear = 1996, ToYear = 1998, Team = "Barcelona", Apps = 26, Goals = 7 },
                new PlayerTeam { PlayerID = 1, FromYear = 1998, ToYear = 1998, Team = "CSKA Sofia", Apps = 4, Goals = 1 },
                new PlayerTeam { PlayerID = 1, FromYear = 1998, ToYear = 1998, Team = "Al-Nassr", Apps = 2, Goals = 1 },
                new PlayerTeam { PlayerID = 1, FromYear = 1998, ToYear = 1999, Team = "Kashiwa Reysol", Apps = 27, Goals = 12 },
                new PlayerTeam { PlayerID = 1, FromYear = 2000, ToYear = 2002, Team = "Chicago Fire", Apps = 51, Goals = 17 },
                new PlayerTeam { PlayerID = 1, FromYear = 2003, ToYear = 2003, Team = "D.C. United", Apps = 21, Goals = 5 }
            );
            context.PlayerTeams.AddOrUpdate(
                new PlayerTeam { PlayerID = 2, FromYear = 1993, ToYear = 1994, Team = "Cruzeiro", Apps = 14, Goals = 12 },
                new PlayerTeam { PlayerID = 2, FromYear = 1994, ToYear = 1996, Team = "PSV", Apps = 46, Goals = 42 },
                new PlayerTeam { PlayerID = 2, FromYear = 1996, ToYear = 1997, Team = "Barcelona", Apps = 37, Goals = 34 },
                new PlayerTeam { PlayerID = 2, FromYear = 1997, ToYear = 2002, Team = "Inter Milan", Apps = 68, Goals = 49 },
                new PlayerTeam { PlayerID = 2, FromYear = 2002, ToYear = 2007, Team = "Real Madrid", Apps = 127, Goals = 83 },
                new PlayerTeam { PlayerID = 2, FromYear = 2007, ToYear = 2008, Team = "Milan", Apps = 20, Goals = 9 },
                new PlayerTeam { PlayerID = 2, FromYear = 2009, ToYear = 2011, Team = "Corinthians", Apps = 31, Goals = 18 }
            );
            context.PlayerTeams.AddOrUpdate(
                new PlayerTeam { PlayerID = 3, FromYear = 1985, ToYear = 1988, Team = "Crewe Alexandra", Apps = 134, Goals = 56 },
                new PlayerTeam { PlayerID = 3, FromYear = 1988, ToYear = 1991, Team = "Aston Villa", Apps = 121, Goals = 50 },
                new PlayerTeam { PlayerID = 3, FromYear = 1991, ToYear = 1992, Team = "Bari", Apps = 29, Goals = 11 },
                new PlayerTeam { PlayerID = 3, FromYear = 1992, ToYear = 1993, Team = "Juventus", Apps = 16, Goals = 3 },
                new PlayerTeam { PlayerID = 3, FromYear = 1993, ToYear = 1995, Team = "Sampdoria", Apps = 55, Goals = 17 },
                new PlayerTeam { PlayerID = 3, FromYear = 1995, ToYear = 1998, Team = "Arsenal", Apps = 88, Goals = 13 },
                new PlayerTeam { PlayerID = 3, FromYear = 1999, ToYear = 2001, Team = "Nottingham Forest", Apps = 5, Goals = 1 }
            );

            context.Locations.AddOrUpdate(
                new Location { ID = 1, ParentID = null, Name = "Asia", Population = null },
                new Location { ID = 2, ParentID = 1, Name = "China", Population = null },
                new Location { ID = 3, ParentID = 1, Name = "Japan", Population = null },
                new Location { ID = 4, ParentID = 1, Name = "Mongolia", Population = null },
                new Location { ID = 5, ParentID = null, Name = "North America", Population = null },
                new Location { ID = 6, ParentID = 5, Name = "USA", Population = null },
                new Location { ID = 7, ParentID = 6, Name = "California", Population = 39144818 },
                new Location { ID = 8, ParentID = 6, Name = "Florida", Population = 20271272 },
                new Location { ID = 9, ParentID = 5, Name = "Canada", Population = null },
                new Location { ID = 10, ParentID = 5, Name = "Mexico", Population = null },
                new Location { ID = 11, ParentID = null, Name = "South America", Population = null },
                new Location { ID = 12, ParentID = 11, Name = "Brazil", Population = null },
                new Location { ID = 13, ParentID = 11, Name = "Argentina", Population = null },
                new Location { ID = 14, ParentID = 11, Name = "Columbia", Population = null },
                new Location { ID = 15, ParentID = null, Name = "Europe", Population = null },
                new Location { ID = 16, ParentID = 15, Name = "France", Population = null },
                new Location { ID = 17, ParentID = 15, Name = "Spain", Population = null },
                new Location { ID = 18, ParentID = 15, Name = "Italy", Population = null }
            );
        }
    }
}
