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

                records = locations.Where(l => l.ParentID == null).OrderBy(l => l.OrderNumber)
                    .Select(l => new Models.DTO.Location
                    {
                        id = l.ID,
                        text = l.Name,
                        @checked = l.Checked,
                        population = l.Population,
                        flagUrl = l.FlagUrl,
                        children = GetChildren(locations, l.ID)
                    }).ToList();
            }

            return this.Json(records, JsonRequestBehavior.AllowGet);
        }

        private List<Models.DTO.Location> GetChildren(List<Location> locations, int parentId)
        {
            return locations.Where(l => l.ParentID == parentId).OrderBy(l => l.OrderNumber)
                .Select(l => new Models.DTO.Location
                {
                    id = l.ID,
                    text = l.Name,
                    population = l.Population,
                    flagUrl = l.FlagUrl,
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

        [HttpPost]
        public JsonResult ChangeNodePosition(int id, int parentId, int orderNumber)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var location = context.Locations.First(l => l.ID == id);

                var newSiblingsBelow = context.Locations.Where(l => l.ParentID == parentId && l.OrderNumber >= orderNumber);
                foreach (var sibling in newSiblingsBelow)
                {
                    sibling.OrderNumber = sibling.OrderNumber + 1;
                }

                var oldSiblingsBelow = context.Locations.Where(l => l.ParentID == location.ParentID && l.OrderNumber > location.OrderNumber);
                foreach (var sibling in oldSiblingsBelow)
                {
                    sibling.OrderNumber = sibling.OrderNumber - 1;
                }


                location.ParentID = parentId;
                location.OrderNumber = orderNumber;

                context.SaveChanges();
            }

            return this.Json(true);
        }
    }
}