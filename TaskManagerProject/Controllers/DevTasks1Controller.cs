using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManagerProject.Models;

namespace TaskManagerProject.Controllers
{
    public class DevTasks1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DevTasks1
        public ActionResult Index()
        {
            var devTasks = db.DevTasks.Include(d => d.Project);
            return View(devTasks.ToList());
        }

        // GET: DevTasks1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevTask devTask = db.DevTasks.Find(id);
            if (devTask == null)
            {
                return HttpNotFound();
            }
            return View(devTask);
        }

        // GET: DevTasks1/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            return View();
        }

        // POST: DevTasks1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,StartDate,Deadline,PercentCompleted,IsComplete,ProjectId,Priority")] DevTask devTask)
        {
            if (ModelState.IsValid)
            {
                db.DevTasks.Add(devTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", devTask.ProjectId);
            return View(devTask);
        }

        // GET: DevTasks1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevTask devTask = db.DevTasks.Find(id);
            if (devTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", devTask.ProjectId);
            return View(devTask);
        }

        // POST: DevTasks1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,StartDate,Deadline,PercentCompleted,IsComplete,ProjectId,Priority")] DevTask devTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(devTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", devTask.ProjectId);
            return View(devTask);
        }

        // GET: DevTasks1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevTask devTask = db.DevTasks.Find(id);
            if (devTask == null)
            {
                return HttpNotFound();
            }
            return View(devTask);
        }

        // POST: DevTasks1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DevTask devTask = db.DevTasks.Find(id);
            db.DevTasks.Remove(devTask);
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
