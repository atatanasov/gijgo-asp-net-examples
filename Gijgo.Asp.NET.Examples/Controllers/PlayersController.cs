using Gijgo.Asp.NET.Examples.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Gijgo.Asp.NET.Examples.Controllers
{
    public class PlayersController : Controller
    {
        public JsonResult Get(int? page, int? limit, string sortBy, string direction, string name, string nationality, string placeOfBirth)
        {
            List<Models.DTO.Player> records;
            int total;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var query = context.Players.Select(p => new Models.DTO.Player
                {
                    ID = p.ID,
                    Name = p.Name,
                    PlaceOfBirth = p.PlaceOfBirth,
                    DateOfBirth = p.DateOfBirth,
                    Nationality = p.Country != null ? p.Country.Name : "",
                    IsActive = p.IsActive,
                    OrderNumber = p.OrderNumber
                });

                if (!string.IsNullOrWhiteSpace(name))
                {
                    query = query.Where(q => q.Name.Contains(name));
                }

                if (!string.IsNullOrWhiteSpace(nationality))
                {
                    query = query.Where(q => q.Nationality != null && q.Nationality.Contains(nationality));
                }

                if (!string.IsNullOrWhiteSpace(placeOfBirth))
                {
                    query = query.Where(q => q.PlaceOfBirth != null && q.PlaceOfBirth.Contains(placeOfBirth));
                }

                if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
                {
                    if (direction.Trim().ToLower() == "asc")
                    {
                        switch (sortBy.Trim().ToLower())
                        {
                            case "name":
                                query = query.OrderBy(q => q.Name);
                                break;
                            case "nationality":
                                query = query.OrderBy(q => q.Nationality);
                                break;
                            case "placeOfBirth":
                                query = query.OrderBy(q => q.PlaceOfBirth);
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
                                query = query.OrderByDescending(q => q.Name);
                                break;
                            case "nationality":
                                query = query.OrderByDescending(q => q.Nationality);
                                break;
                            case "placeOfBirth":
                                query = query.OrderByDescending(q => q.PlaceOfBirth);
                                break;
                            case "dateofbirth":
                                query = query.OrderByDescending(q => q.DateOfBirth);
                                break;
                        }
                    }
                }
                else
                {
                    query = query.OrderBy(q => q.OrderNumber);
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
                    entity.DateOfBirth = record.DateOfBirth;
                    entity.Country = context.Locations.FirstOrDefault(l => l.Name == record.Nationality);
                    entity.IsActive = record.IsActive;
                }
                else
                {
                    context.Players.Add(new Player
                    {
                        Name = record.Name,
                        PlaceOfBirth = record.PlaceOfBirth,
                        DateOfBirth = record.DateOfBirth,
                        Country = context.Locations.FirstOrDefault(l => l.Name == record.Nationality),
                        IsActive = record.IsActive
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

        public JsonResult GetTeams(int playerId, int? page, int? limit)
        {
            List<Models.DTO.PlayerTeam> records;
            int total;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var query = context.PlayerTeams.Where(pt => pt.PlayerID == playerId).Select(pt => new Models.DTO.PlayerTeam
                {
                    ID = pt.ID,
                    PlayerID = pt.PlayerID,
                    FromYear = pt.FromYear,
                    ToYear = pt.ToYear,
                    Team = pt.Team,
                    Apps = pt.Apps,
                    Goals = pt.Goals
                });

                total = query.Count();
                if (page.HasValue && limit.HasValue)
                {
                    int start = (page.Value - 1) * limit.Value;
                    records = query.OrderBy(pt => pt.FromYear).Skip(start).Take(limit.Value).ToList();
                }
                else
                {
                    records = query.ToList();
                }
            }

            return this.Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }
    }
}
