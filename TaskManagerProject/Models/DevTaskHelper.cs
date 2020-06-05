using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManagerProject.Models
{
    [Authorize(Roles = "ProjectManager")]
    public class DevTaskHelper
    {
        public virtual Project Project { get; set; }
        public virtual DevTask DevTask { get; set; }

        static ApplicationDbContext db = new ApplicationDbContext();

        static UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>
            (new UserStore<ApplicationUser>(db));

        static RoleManager<IdentityRole> projectManager = new RoleManager<IdentityRole>
            (new RoleStore<IdentityRole>(db));

        public List<string> GetAllTasks()
        {
            var result = db.DevTasks.Select(t => t.Name).ToList();

            return result;
        }

        public ICollection<int> TasksForUser(string userId)
        {
            var result = db.DevTasks.Where(up => up.ApplicationUsers.Select(d => d.Id).Contains(userId)).Select(t => t.Id);

            return result.ToList();
        }
        public ICollection<int> TasksForProject(int projectId)
        {
            var result = db.DevTasks.Where(up => up.Project.Id == projectId).Select(t => t.Id);

            return result.ToList();
        }
        public DevTask CreateDevTask(string name, string description, DateTime deadline)
        {
            DevTask newTask = new DevTask
            {
                Name = name,
                Description = description,
                StartDate = DateTime.Now,
                //Deadline = deadline,
                PercentCompleted = 0,
                //IsCompleted = false,
            };
            return newTask;
        }
        public void AssignDevTask(ApplicationUser user, DevTask task)
        {
            if(UserManager.checkUserRole(user.Id, "Developer"))
            {
                user.DevTasks.Add(task);
                task.ApplicationUsers.Add(user);
            }
        }
        public void AssignDevsToTask(List<ApplicationUser> devs, DevTask task)
        {
            foreach(ApplicationUser dev in devs)
            {
                if (!dev.DevTasks.Contains(task) && !task.ApplicationUsers.Contains(dev))
                {
                    AssignDevTask(dev, task);
                }
            }
        } 
        public void UpdateDevTask(DevTask task)
        {
            
        }
        public void  DeleteDevTask(DevTask task)
        {
            db.DevTasks.Remove(task);
        }

        public void AddComment(string comment,DevTask task)
        {
            task.Comments.Add(comment);
        }
        public void UpdateCompletionPercent(double newValue, DevTask task)
        {
            if (newValue <= 100)
            {
                task.PercentCompleted = newValue;
                if (newValue == 100)
                {
                    task.IsComplete = true;
                }
                else
                {
                    task.IsComplete = false;
                }
            }
            else
            {
                //error
            }
        }
        public void SendNotification(string title, string description, ApplicationUser user, Project project, DevTask task)
        {
            Notification notification = new Notification
            {
                Title = title,
                Description = description,
                ApplicationUserId = user.Id,
                ProjectId = project.Id,
                DevTaskId = task.Id,
            };
            user.Notifications.Add(notification);
        }
        //SendDeadlineAlert(Project) 
        //SendBugNotification(Task)

    }
}