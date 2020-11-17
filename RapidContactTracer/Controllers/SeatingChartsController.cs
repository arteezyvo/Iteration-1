using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RapidContactTracer.Models;

namespace RapidContactTracer.Controllers
{
    public class SeatingChartsController : Controller
    {
        private SeatingChartDBContext db = new SeatingChartDBContext();

        // GET: SeatingCharts
        public ActionResult Index()
        {
            return View(db.SeatingCharts.ToList());
        }

        // GET: SeatingCharts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatingChart seatingChart = db.SeatingCharts.Find(id);
            if (seatingChart == null)
            {
                return HttpNotFound();
            }
            return View(seatingChart);
        }

        // GET: SeatingCharts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeatingCharts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,SeatingID,Email")] SeatingChart seatingChart)
        {
            if (ModelState.IsValid)
            {
                db.SeatingCharts.Add(seatingChart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seatingChart);
        }

        // GET: SeatingCharts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatingChart seatingChart = db.SeatingCharts.Find(id);
            if (seatingChart == null)
            {
                return HttpNotFound();
            }
            return View(seatingChart);
        }

        // POST: SeatingCharts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,SeatingID,Email")] SeatingChart seatingChart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seatingChart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seatingChart);
        }

        // GET: SeatingCharts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatingChart seatingChart = db.SeatingCharts.Find(id);
            if (seatingChart == null)
            {
                return HttpNotFound();
            }
            return View(seatingChart);
        }

        // POST: SeatingCharts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeatingChart seatingChart = db.SeatingCharts.Find(id);
            db.SeatingCharts.Remove(seatingChart);
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
