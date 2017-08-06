using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gijgo.Asp.NET.Examples.Models.Entities
{
    public class Player
    {
        public Player()
        {
            this.Teams = new HashSet<PlayerTeam>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string PlaceOfBirth { get; set; }

        public int CountryID { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }

        public bool IsActive { get; set; }

        public int OrderNumber { get; set; }

        public virtual ICollection<PlayerTeam> Teams { get; set; }

        public virtual Location Country { get; set; }
    }
}