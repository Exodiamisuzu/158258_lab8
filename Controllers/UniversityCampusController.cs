using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab8.Data;
using lab8.Models;

namespace lab8.Controllers
{
    public class UniversityCampusController : Controller
    {
        private lab8Context db = new lab8Context();

        // GET: UniversityCampus
        public ActionResult Index()
        {
            return View(db.UniversityCampus.ToList());
        }

        // GET: UniversityCampus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityCampus universityCampus = db.UniversityCampus.Find(id);
            if (universityCampus == null)
            {
                return HttpNotFound();
            }
            return View(universityCampus);
        }

        // GET: UniversityCampus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniversityCampus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] UniversityCampus universityCampus)
        {
            if (ModelState.IsValid)
            {
                db.UniversityCampus.Add(universityCampus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(universityCampus);
        }

        // GET: UniversityCampus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityCampus universityCampus = db.UniversityCampus.Find(id);
            if (universityCampus == null)
            {
                return HttpNotFound();
            }
            return View(universityCampus);
        }

        // POST: UniversityCampus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] UniversityCampus universityCampus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universityCampus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(universityCampus);
        }

        // GET: UniversityCampus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityCampus universityCampus = db.UniversityCampus.Find(id);
            if (universityCampus == null)
            {
                return HttpNotFound();
            }
            return View(universityCampus);
        }

        // POST: UniversityCampus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UniversityCampus universityCampus = db.UniversityCampus.Find(id);
            db.UniversityCampus.Remove(universityCampus);
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
