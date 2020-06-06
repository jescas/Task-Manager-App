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
    public class DevTasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: DevTasks
        public ActionResult Index()
        {
            var devTasks = db.DevTasks.Include(d => d.Project);
            return View(devTasks.ToList());
        }

        // GET: DevTasks/Details/5
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

        // GET: DevTasks/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            return View();
        }

        // POST: DevTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,StartDate,PercentCompleted,IsComplete,ProjectId")] DevTask devTask)
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

        // GET: DevTasks/Edit/5
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

        // POST: DevTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,StartDate,PercentCompleted,IsComplete,ProjectId")] DevTask devTask)
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

        // GET: DevTasks/UpdateCompletionPercentage/5 
        public ActionResult UpdateCompletionPercentage(int? id)
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

        // POST: DevTasks/UpdateCompletionPercentage/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCompletionPercentage(double percent, DevTask devTask)
        {
            if (ModelState.IsValid)
            {
                DevTaskHelper.UpdateCompletionPercent(percent, devTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(devTask);
        }
        // GET: DevTasks/AssignDevs/5
        public ActionResult AssignDevs(int? id)
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

        // POST: DevTasks/AssignDevs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /*  [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult AssignDevs([Bind(Include = "Id,Name,Description,StartDate,PercentCompleted,IsComplete,ProjectId")] DevTask devTask)
          {
              if (ModelState.IsValid)
              {
                  List<ApplicationUser> devs = ;
                  DevTaskHelper.AssignDevsToTask(devs, devTask);
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }
              return View(devTask);
          }*/
        // GET: DevTasks/Edit/5
        /* public ActionResult SetPriority(int? id)
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
             ViewBag.ProjectId = new SelectList(db.DevTasks, "Id", "Name", devTask.Priority);
             return View(devTask);
         }

         // POST: DevTasks/Edit/5
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult SetPriority([Bind(Include = "Id,Name,Description,StartDate,PercentCompleted,IsComplete,ProjectId")] DevTask devTask)
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
                 // GET: DevTasks/Edit/5
        /* public ActionResult SetPriority(int? id)
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
             ViewBag.ProjectId = new SelectList(db.DevTasks, "Id", "Name", devTask.Priority);
             return View(devTask);
         }

         // POST: DevTasks/Edit/5
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult ReportBug(int taskId, string description)
         {
             if (ModelState.IsValid)
             {
                 DevTask devTask = db.DevTasks.Find(taskId); 
                 dth.SendBugReport(devTask, description);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             return View(devTask);*/

        // GET: DevTasks/Delete/5
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

        // POST: DevTasks/Delete/5
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
