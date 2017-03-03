namespace Gijgo.Asp.NET.Examples.Models.Entities
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

        public virtual Player Player { get; set; }
    }
}