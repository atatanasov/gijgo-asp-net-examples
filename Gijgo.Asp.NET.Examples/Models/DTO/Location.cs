using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gijgo.Asp.NET.Examples.Models.DTO
{
    public class Location
    {
        public int id { get; set; }

        public string text { get; set; }

        public long? population { get; set; }

        public bool @checked { get; set; }

        public virtual List<Location> children { get; set; }
    }
}