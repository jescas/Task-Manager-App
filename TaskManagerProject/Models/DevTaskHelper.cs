using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerProject.Models
{
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

        public static ICollection<int> TasksForUser(string userId)
        {
            var result = db.DevTasks.Where(up => up.ApplicationUsers.Select(d => d.Id).Contains(userId)).Select(t => t.Id);

            return result.ToList();
        }
        public static ICollection<int> TasksForProject(int projectId)
        {
            var result = db.DevTasks.Where(up => up.Project.Id == projectId).Select(t => t.Id);

            return result.ToList();
        }
        public static DevTask CreateDevTask(string name, string description, DateTime deadline)
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
        public static void AssignDevTask(ApplicationUser user, DevTask task)
        {
            if(user.Roles.Contains("Developer"))
            {
                user.DevTasks.Add(task);
                task.ApplicationUsers.Add(user);
            }
        }
        public static void AssignDevsToTask(List<ApplicationUser> devs, DevTask task)
        {
            foreach(ApplicationUser dev in devs)
            {
                if (!dev.DevTasks.Contains(task) && !task.ApplicationUsers.Contains(dev))
                {
                    AssignDevTask(dev, task);
                }
            }
        } 
        public static void UpdateDevTask(DevTask task)
        {
            
        }
        public static void  DeleteDevTask(DevTask task)
        {
            db.DevTasks.Remove(task);
        }

        //AddComment(string comment,int taskId) 
        //UpdateCompletionPercent(int newValue, int taskId)
        //SendDeadlineAlert() 
        //SendBugNotification

    }
}