using Microsoft.AspNet.Identity;
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
            string currentUser = User.Identity.GetUserId();
            var devTasks = db.DevTasks.Include(d => d.Project);
            if(currentUser != null)
            {
                if (UserManager.checkUserRole(currentUser, "Project Manager"))
                {
                    devTasks = db.DevTasks.Include(d => d.Project);
                }
                else if(UserManager.checkUserRole(currentUser, "Developer"))
                {
                    ApplicationUser user = db.Users.Find(currentUser);
                    devTasks = db.DevTasks.Include(d => d.Project).Where(d => d.ApplicationUsers.Contains(user));
                }
            }
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

        // GET: DevTasks/UpdateCompletion/5 
        public ActionResult UpdateCompletion(int id, bool finish)
        {
            ViewBag.TaskId = id;
            ViewBag.Finish = finish;
            return PartialView();
        }
        // POST: DevTasks/UpdateCompletion/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCompletion(double percent, int id)
        {
            DevTask devTask = db.DevTasks.Find(id);
            if (ModelState.IsValid)
            {
                DevTaskHelper.UpdateCompletionPercent(percent, devTask);
                db.SaveChanges();
                if(percent == 100)
                {
                    return RedirectToAction("AddNewComment", devTask);
                }
                return RedirectToAction("Index");
            }
            return PartialView();
        }

        // GET: DevTasks/AddComment/5 
        public ActionResult AddNewComment(int id)
        {
            ViewBag.Comment = "comment"; 
            ViewBag.TaskId = id;
            return PartialView(id);
        }
        // POST: DevTasks/AddComment/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewComment(string comment, int id)
        {
            /*if (ModelState.IsValid)
            {
                DevTaskHelper.AddComment(comment, id);
                db.SaveChanges();

                return RedirectToAction("Index");
            }*/

            return PartialView(id);
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
         }*/
        // GET: DevTasks/Edit/5
        public ActionResult ReportBug(int id)
        {
            ViewBag.TaskId = id;
            return PartialView(id);
        }

        // POST: DevTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReportBug(int taskId, string description)
        {
            DevTask devTask = db.DevTasks.Find(taskId);
            if (ModelState.IsValid)
            {

                DevTaskHelper.SendBugReport(devTask, description);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(devTask);
        }
    }
}
