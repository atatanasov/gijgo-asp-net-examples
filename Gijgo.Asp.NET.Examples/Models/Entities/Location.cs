using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gijgo.Asp.NET.Examples.Models.Entities
{
    public class Location
    {
        public int ID { get; set; }

        public int? ParentID { get; set; }

        public string Name { get; set; }

        public long? Population { get; set; }

        public bool Checked { get; set; }

        public int OrderNumber { get; set; }

        public virtual Location Parent { get; set; }

        public virtual List<Location> Children { get; set; }
    }
}