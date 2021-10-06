using LapTimeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LapTimeTracker.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
      
        public ActionResult Index()
        {
            List<Racer> prijave = db.Racers.Where(x => x.RecordStatus > 0 && x.AppStatus == Status.Novi).ToList();

            return View(prijave.OrderBy(x => x.LastName));
        }


        public ActionResult TopList()
        {
            ViewBag.Admin = true;
            List<Racer> topPlayers = db.Racers.Where(x => x.RecordStatus > 0 && x.AppStatus == Status.Odobren).OrderBy(x => x.LapTimeTicks).ToList();
            return View(topPlayers);
        }



        [HttpPost]
        public JsonResult Odobri(int id)
        {
            var racer = db.Racers.Where(x => x.Id == id).SingleOrDefault();

            if (racer != null)
            {
                racer.AppStatus = Status.Odobren;
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult Izbrisi(int id)
        {
            var racer = db.Racers.Where(x => x.Id == id).SingleOrDefault();

            if (racer != null)
            {
                racer.RecordStatus = 0;
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }
    }
}