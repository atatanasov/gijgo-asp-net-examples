using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gijgo.Asp.NET.Examples.Models.DTO
{
    public class PlayerTeam
    {
        public int ID { get; set; }
        public int PlayerID { get; set; }
        public int FromYear { get; set; }
        public int ToYear { get; set; }
        public string Team { get; set; }
        public int Apps { get; set; }
        public int Goals { get; set; }
    }
}