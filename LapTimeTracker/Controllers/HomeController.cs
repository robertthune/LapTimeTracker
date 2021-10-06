using LapTimeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LapTimeTracker.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Racer
        public ActionResult Index()
        {
            return View(new LapTimeViewModel());
        }

        public ActionResult TopLista(bool admin)
        {
            ViewBag.Admin = admin;
            List<Racer> topPlayers = db.Racers.Where(x => x.RecordStatus > 0 && x.AppStatus == Status.Odobren).OrderBy(x => x.LapTimeTicks).ToList();
            return PartialView("_TopLista", topPlayers);
        }

        public JsonResult Novi(LapTimeViewModel item)
        {
            if (ModelState.IsValid)
            {
                var racer = item.Racer;
                racer.LapTimeTicks = new TimeSpan(0, item.LapHours, item.LapMinutes, item.LapSeconds, item.LapMiliSeconds).Ticks;
                db.Racers.Add(racer);
                db.SaveChanges();

                return Json(new { success = true });
            }

            return Json(new { success = false });

        }
    }
}