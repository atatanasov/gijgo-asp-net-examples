using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gijgo.Asp.NET.Examples.Controllers
{
    public class PlayersController : Controller
    {        
        public JsonResult Get(int id)
        {
            return Json(new { });
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
