namespace Gijgo.Asp.NET.Examples.Migrations
{
    using Gijgo.Asp.NET.Examples.Models.Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Locations.AddOrUpdate(
                new Location { ID = 1, ParentID = null, Name = "Asia", OrderNumber = 1, Population = null },
                new Location { ID = 2, ParentID = 1, Name = "China", OrderNumber = 1, Population = 1373541278, FlagUrl = "http://code.gijgo.com/flags/24/China.png" },
                new Location { ID = 3, ParentID = 1, Name = "Japan", OrderNumber = 2, Population = 126730000, FlagUrl = "http://code.gijgo.com/flags/24/Japan.png" },
                new Location { ID = 4, ParentID = 1, Name = "Mongolia", OrderNumber = 3, Population = 3081677, FlagUrl = "http://code.gijgo.com/flags/24/Mongolia.png" },
                new Location { ID = 5, ParentID = null, Name = "North America", OrderNumber = 2, Population = null },
                new Location { ID = 6, ParentID = 5, Name = "USA", OrderNumber = 1, Population = 325145963, FlagUrl = "http://code.gijgo.com/flags/24/United%20States%20of%20America(USA).png" },
                new Location { ID = 7, ParentID = 6, Name = "California", OrderNumber = 1, Population = 39144818 },
                new Location { ID = 8, ParentID = 6, Name = "Florida", OrderNumber = 2, Population = 20271272 },
                new Location { ID = 9, ParentID = 5, Name = "Canada", OrderNumber = 2, Population = 35151728, FlagUrl = "http://code.gijgo.com/flags/24/canada.png" },
                new Location { ID = 10, ParentID = 5, Name = "Mexico", OrderNumber = 3, Population = 119530753, FlagUrl = "http://code.gijgo.com/flags/24/mexico.png" },
                new Location { ID = 11, ParentID = null, Name = "South America", OrderNumber = 3, Population = null },
                new Location { ID = 12, ParentID = 11, Name = "Brazil", OrderNumber = 1, Population = 207350000, FlagUrl = "http://code.gijgo.com/flags/24/brazil.png" },
                new Location { ID = 13, ParentID = 11, Name = "Argentina", OrderNumber = 2, Population = 43417000, FlagUrl = "http://code.gijgo.com/flags/24/argentina.png" },
                new Location { ID = 14, ParentID = 11, Name = "Colombia", OrderNumber = 3, Population = 49819638, FlagUrl = "http://code.gijgo.com/flags/24/colombia.png" },
                new Location { ID = 15, ParentID = null, Name = "Europe", OrderNumber = 4, Population = null },
                new Location { ID = 16, ParentID = 15, Name = "England", OrderNumber = 1, Population = 54786300, FlagUrl = "http://code.gijgo.com/flags/24/england.png" },
                new Location { ID = 17, ParentID = 15, Name = "Germany", OrderNumber = 2, Population = 82175700, FlagUrl = "http://code.gijgo.com/flags/24/germany.png" },
                new Location { ID = 18, ParentID = 15, Name = "Bulgaria", OrderNumber = 3, Population = 7101859, FlagUrl = "http://code.gijgo.com/flags/24/bulgaria.png" },
                new Location { ID = 19, ParentID = 15, Name = "Poland", OrderNumber = 4, Population = 38454576, FlagUrl = "http://code.gijgo.com/flags/24/poland.png" }
            );

            context.Players.AddOrUpdate(
              new Player { ID = 1, Name = "Hristo Stoichkov", PlaceOfBirth = "Plovdiv, Bulgaria", DateOfBirth = new System.DateTime(1966, 02, 08), OrderNumber = 1, CountryID = 18, IsActive = false },
              new Player { ID = 2, Name = "Ronaldo Luís Nazário de Lima", PlaceOfBirth = "Rio de Janeiro, Brazil", DateOfBirth = new System.DateTime(1976, 09, 18), OrderNumber = 2, CountryID = 12, IsActive = false },
              new Player { ID = 3, Name = "David Platt", PlaceOfBirth = "Chadderton, Lancashire, England", DateOfBirth = new System.DateTime(1966, 06, 10), OrderNumber = 3, CountryID = 16, IsActive = false },
              new Player { ID = 4, Name = "Manuel Neuer", PlaceOfBirth = "Gelsenkirchen, West Germany", DateOfBirth = new System.DateTime(1986, 03, 27), OrderNumber = 4, CountryID = 17, IsActive = true },
              new Player { ID = 5, Name = "James Rodríguez", PlaceOfBirth = "Cúcuta, Colombia", DateOfBirth = new System.DateTime(1991, 07, 12), OrderNumber = 5, CountryID = 14, IsActive = true },
              new Player { ID = 6, Name = "Dimitar Berbatov", PlaceOfBirth = "Blagoevgrad, Bulgaria", DateOfBirth = new System.DateTime(1981, 01, 30), OrderNumber = 6, CountryID = 18, IsActive = false },
              new Player { ID = 7, Name = "Robert Lewandowski", PlaceOfBirth = "Warsaw, Poland", DateOfBirth = new System.DateTime(1988, 08, 21), OrderNumber = 7, CountryID = 19, IsActive = true }
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
        }
    }
}
