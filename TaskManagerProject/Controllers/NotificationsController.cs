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
    public class NotificationsController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        // GET: Notifications
        public ActionResult Index()
        {
            var notifications = db.Notifications.Include(n => n.ApplicationUser).Include(n => n.DevTask).Include(n => n.Project);
            return View(notifications.ToList());
        }

        // GET: Notifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notification notification = db.Notifications.Find(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // GET: Notifications/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
            ViewBag.DevTaskId = new SelectList(db.DevTasks, "Id", "Name");
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            return View();
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,isOpened,ApplicationUserId,DevTaskId,ProjectId")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                db.Notifications.Add(notification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", notification.ApplicationUserId);
            ViewBag.DevTaskId = new SelectList(db.DevTasks, "Id", "Name", notification.DevTaskId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", notification.ProjectId);
            return View(notification);
        }

        // GET: Notifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notification notification = db.Notifications.Find(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", notification.ApplicationUserId);
            ViewBag.DevTaskId = new SelectList(db.DevTasks, "Id", "Name", notification.DevTaskId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", notification.ProjectId);
            return View(notification);
        }

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,isOpened,ApplicationUserId,DevTaskId,ProjectId")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", notification.ApplicationUserId);
            ViewBag.DevTaskId = new SelectList(db.DevTasks, "Id", "Name", notification.DevTaskId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", notification.ProjectId);
            return View(notification);
        }

        // GET: Notifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notification notification = db.Notifications.Find(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notification notification = db.Notifications.Find(id);
            db.Notifications.Remove(notification);
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
        public ActionResult ProjectManagerNotifications(string userId)
        {
            var result = db.Notifications.Where(n => n.ApplicationUserId == userId).Select(u => u.Title);
            return View(result);
        }
        public void Notify(string title, string description, Project project, ApplicationUser projectManager)
        {
            Notification notification = new Notification
            {
                Title = title,
                Description = description,
                ProjectId = project.Id,
                ApplicationUserId = projectManager.Id,
            };
            projectManager.Notifications.Add(notification); 
            db.SaveChanges();
        }
        public void ProjectCompletedNotification(Project project, DevTask task)
        {
            string title = project.Name;
            string description = project.Description;
            List<ApplicationUser> users = db.Users.Where(u => UserManager.checkUserRole(u.Id, "Project Manager")).ToList();

            foreach (ApplicationUser projectManager in users)
            {
                if ((project.IsCompleted || task.IsComplete) || (DateTime.Now > project.Deadline && !task.IsComplete))
                {
                    Notify(title, description, project, projectManager);
                }
            }
        }
    }
}
