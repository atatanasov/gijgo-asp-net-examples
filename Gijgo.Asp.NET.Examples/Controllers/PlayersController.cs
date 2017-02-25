using Gijgo.Asp.NET.Examples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gijgo.Asp.NET.Examples.Controllers
{
    public class PlayersController : Controller
    {        
        public JsonResult Get(int? page, int? limit, string sortBy, string direction, string name, string placeOfBirth)
        {
            using (ApplicationDbContext context = new Models.ApplicationDbContext())
            {
                IQueryable<Player> query = context.Players;

                if (!string.IsNullOrWhiteSpace(name))
                {
                    query = query.Where(p => p.Name.Contains(name));
                }

                if (!string.IsNullOrWhiteSpace(placeOfBirth))
                {
                    query = query.Where(p => p.PlaceOfBirth.Contains(placeOfBirth));
                }

                if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
                {
                    if (direction.Trim().ToLower() == "asc")
                    {
                        switch (sortBy.Trim().ToLower())
                        {
                            case "name":
                                query = query.OrderBy(r => r.DateOfBirth);
                                break;
                            case "placeofbirth":
                                query = query.OrderBy(r => r.DateOfBirth);
                                break;
                            case "dateofbirth":
                                query = query.OrderBy(r => r.DateOfBirth);
                                break;
                        }
                    }
                    else
                    {
                        switch (sortBy.Trim().ToLower())
                        {
                            case "name":
                                query = query.OrderByDescending(r => r.DateOfBirth);
                                break;
                            case "placeofbirth":
                                query = query.OrderByDescending(r => r.DateOfBirth);
                                break;
                            case "dateofbirth":
                                query = query.OrderByDescending(r => r.DateOfBirth);
                                break;
                        }
                    }
                }

                List<Player> result;
                int total = query.Count();
                if (page.HasValue && limit.HasValue)
                {
                    int start = (page.Value - 1) * limit.Value;
                    result = query.Skip(start).Take(limit.Value).ToList();
                }
                else
                {
                    result = query.ToList();
                }

                return this.Json(new { result, total }, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpPost]
        public JsonResult Save(int id)
        {
            return Json(new { });
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            return Json(new { });
        }
    }
}
