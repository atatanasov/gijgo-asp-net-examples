using Gijgo.Asp.NET.Examples.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Gijgo.Asp.NET.Examples.Controllers
{
    public class PlayersController : Controller
    {        
        public JsonResult Get(int? page, int? limit, string sortBy, string direction, string name, string placeOfBirth)
        {
            List<Models.DTO.Player> records;
            int total;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var query = context.Players.Select(p => new Models.DTO.Player {
                    ID = p.ID,
                    Name = p.Name,
                    PlaceOfBirth = p.PlaceOfBirth,
                    DateOfBirth = p.DateOfBirth
                });

                if (!string.IsNullOrWhiteSpace(name))
                {
                    query = query.Where(q => q.Name.Contains(name));
                }

                if (!string.IsNullOrWhiteSpace(placeOfBirth))
                {
                    query = query.Where(q => q.PlaceOfBirth.Contains(placeOfBirth));
                }

                if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
                {
                    if (direction.Trim().ToLower() == "asc")
                    {
                        switch (sortBy.Trim().ToLower())
                        {
                            case "name":
                                query = query.OrderBy(q => q.DateOfBirth);
                                break;
                            case "placeofbirth":
                                query = query.OrderBy(q => q.DateOfBirth);
                                break;
                            case "dateofbirth":
                                query = query.OrderBy(q => q.DateOfBirth);
                                break;
                        }
                    }
                    else
                    {
                        switch (sortBy.Trim().ToLower())
                        {
                            case "name":
                                query = query.OrderByDescending(q => q.DateOfBirth);
                                break;
                            case "placeofbirth":
                                query = query.OrderByDescending(q => q.DateOfBirth);
                                break;
                            case "dateofbirth":
                                query = query.OrderByDescending(q => q.DateOfBirth);
                                break;
                        }
                    }
                }
                else
                {
                    query = query.OrderBy(q => q.ID);
                }

                total = query.Count();
                if (page.HasValue && limit.HasValue)
                {
                    int start = (page.Value - 1) * limit.Value;
                    records = query.Skip(start).Take(limit.Value).ToList();
                }
                else
                {
                    records = query.ToList();
                }
            }

            return this.Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult Save(Models.DTO.Player record)
        {
            Player entity;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                if (record.ID > 0)
                {
                    entity = context.Players.First(p => p.ID == record.ID);
                    entity.Name = record.Name;
                    entity.PlaceOfBirth = record.PlaceOfBirth;
                }
                else
                {
                    context.Players.Add(new Player {
                        Name = record.Name,
                        PlaceOfBirth = record.PlaceOfBirth,
                        DateOfBirth = DateTime.MinValue
                    });
                }
                context.SaveChanges();
            }
            return Json(new { result = true });
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Player entity = context.Players.First(p => p.ID == id);
                context.Players.Remove(entity);
                context.SaveChanges();
            }
            return Json(new { result = true });
        }
    }
}
