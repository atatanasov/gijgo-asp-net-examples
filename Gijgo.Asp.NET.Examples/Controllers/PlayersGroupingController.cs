using Gijgo.Asp.NET.Examples.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gijgo.Asp.NET.Examples.Controllers
{
    public class PlayersGroupingController : Controller
    {
        public JsonResult Get(string groupBy, string groupByDirection, int? page, int? limit)
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
                    Nationality = p.Country.Name,
                    OrderNumber = p.OrderNumber
                });

                if (groupBy == "Nationality")
                {
                    if (groupByDirection.Trim().ToLower() == "asc")
                    {
                        query = query.OrderBy(q => q.Nationality).ThenBy(q => q.OrderNumber);
                    }
                    else
                    {
                        query = query.OrderByDescending(q => q.Nationality).ThenBy(q => q.OrderNumber);
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

    }
}