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
    public class EmployeesController : Controller
    {
        private ScheduleProdEntities db = new ScheduleProdEntities();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.EmpDemographics.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpDemographic empDemographic = db.EmpDemographics.Find(id);
            if (empDemographic == null)
            {
                return HttpNotFound();
            }
            return View(empDemographic);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpID,EmpFirstName,RoleID,EmailAddress,StartDate,EndDate,EmpLastName,EmpPhone,Password")] EmpDemographic empDemographic)
        {
            if (ModelState.IsValid)
            {
                db.EmpDemographics.Add(empDemographic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empDemographic);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpDemographic empDemographic = db.EmpDemographics.Find(id);
            if (empDemographic == null)
            {
                return HttpNotFound();
            }
            return View(empDemographic);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpID,EmpFirstName,RoleID,EmailAddress,StartDate,EndDate,EmpLastName,EmpPhone,Password")] EmpDemographic empDemographic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empDemographic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empDemographic);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpDemographic empDemographic = db.EmpDemographics.Find(id);
            if (empDemographic == null)
            {
                return HttpNotFound();
            }
            return View(empDemographic);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpDemographic empDemographic = db.EmpDemographics.Find(id);
            db.EmpDemographics.Remove(empDemographic);
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
