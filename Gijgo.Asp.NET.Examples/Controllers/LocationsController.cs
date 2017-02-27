using Gijgo.Asp.NET.Examples.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Gijgo.Asp.NET.Examples.Controllers
{
    public class LocationsController : Controller
    {
        public JsonResult Get()
        {
            List<Location> locations;
            List<Models.DTO.Location> records;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                locations = context.Locations.ToList();

                records = locations.Where(r => r.ParentID == null).Select(l => new Models.DTO.Location
                {
                    id = l.ID,
                    text = l.Name,
                    population = l.Population,
                    @checked = l.Checked,
                    children = GetChildren(locations, l.ID)
                }).ToList();
            }

            return this.Json(records, JsonRequestBehavior.AllowGet);
        }

        private List<Models.DTO.Location> GetChildren(List<Location> locations, int parentId)
        {
            return locations.Where(r => r.ParentID == parentId).Select(l => new Models.DTO.Location
            {
                id = l.ID,
                text = l.Name,
                population = l.Population,
                @checked = l.Checked,
                children = GetChildren(locations, l.ID)
            }).ToList();
        }

        [HttpPost]
        public JsonResult SaveCheckedNodes(List<int> checkedIds)
        {
            if (checkedIds != null)
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    var locations = context.Locations.ToList();
                    foreach (var location in locations)
                    {
                        location.Checked = checkedIds.Contains(location.ID);
                    }
                    context.SaveChanges();
                }
            }

            return this.Json(true);
        }
    }
}