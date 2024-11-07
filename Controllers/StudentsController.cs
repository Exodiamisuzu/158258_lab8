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
using lab8.ViewModels;
using PagedList;

namespace lab8.Controllers
{
    public class StudentsController : Controller
    {
        private lab8Context db = new lab8Context();

        // GET: Students
        public ActionResult Index(StudentSearchViewModel model, string sortBy,int? page)
        {
            var students = db.Students.Include(s => s.UniversityCampus).AsQueryable();
            StudentSearchViewModel studentSearchViewModel = new StudentSearchViewModel();

            if (!string.IsNullOrEmpty(model.SearchString))
            {
                students = students.Where(s => s.Name.Contains(model.SearchString));
                studentSearchViewModel.SearchString = model.SearchString;
            }

            if (model.CampusId.HasValue)
            {
                students = students.Where(s => s.UniversityCampusID == model.CampusId);
            }

            studentSearchViewModel.SortBy = sortBy;
            switch (sortBy)
            {
                case "NameDesc":
                    students = students.OrderByDescending(s => s.Name);
                    break;
                default:
                    students = students.OrderBy(s => s.Name);
                    break;
            }

            //model.Students = students.ToList();
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            model.Students = students.ToPagedList(pageNumber, pageSize);
            model.Campuses = new SelectList(db.UniversityCampus, "ID", "Name");
            model.SortBy = sortBy;
            model.SortOptions = new Dictionary<string, string>
            {
                { "NameAsc", "Name (A-Z)" },
                { "NameDesc", "Name (Z-A)" }
            };
            return View(model);
        }



        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.UniversityCampusID = new SelectList(db.UniversityCampus, "ID", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,UniversityCampusID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UniversityCampusID = new SelectList(db.UniversityCampus, "ID", "Name", student.UniversityCampusID);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.UniversityCampusID = new SelectList(db.UniversityCampus, "ID", "Name", student.UniversityCampusID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,UniversityCampusID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UniversityCampusID = new SelectList(db.UniversityCampus, "ID", "Name", student.UniversityCampusID);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
