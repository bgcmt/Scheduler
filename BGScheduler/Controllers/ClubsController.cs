using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BGScheduler;

namespace BGScheduler.Controllers
{
    public class ClubsController : Controller
    {
        private ScheduleProdEntities db = new ScheduleProdEntities();

        // GET: Clubs
        public ActionResult Index()
        {
            return View(db.ClubDemographics.ToList());
        }

        // GET: Clubs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubDemographic clubDemographic = db.ClubDemographics.Find(id);
            if (clubDemographic == null)
            {
                return HttpNotFound();
            }
            return View(clubDemographic);
        }

        // GET: Clubs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClubID,ClubName,ClubAddress,ClubPhone,ClubDirectorID,ClubCity,ClubState,ClubZip")] ClubDemographic clubDemographic)
        {
            if (ModelState.IsValid)
            {
                db.ClubDemographics.Add(clubDemographic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clubDemographic);
        }

        // GET: Clubs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubDemographic clubDemographic = db.ClubDemographics.Find(id);
            if (clubDemographic == null)
            {
                return HttpNotFound();
            }
            return View(clubDemographic);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClubID,ClubName,ClubAddress,ClubPhone,ClubDirectorID,ClubCity,ClubState,ClubZip")] ClubDemographic clubDemographic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clubDemographic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clubDemographic);
        }

        // GET: Clubs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubDemographic clubDemographic = db.ClubDemographics.Find(id);
            if (clubDemographic == null)
            {
                return HttpNotFound();
            }
            return View(clubDemographic);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClubDemographic clubDemographic = db.ClubDemographics.Find(id);
            db.ClubDemographics.Remove(clubDemographic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
