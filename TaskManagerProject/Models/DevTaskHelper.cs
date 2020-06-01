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
            var result = db.DevTasks.Where(up => up.AppUserId == userId).Select(t => t.DevTaskId);

            return result.ToList();
        }
        public static ICollection<int> TasksForProject(int taskId)
        {
            var result = db.DevTasks.Where(up => up.AppUserId == userId).Select(t => t.DevTaskId);

            return result.ToList();
        }
        public static DevTask CreateDevTask(string name, string description, DateTime deadline)
        {
            newTask = new DevTask
            {
                Name = name,
                Description = description,
                StartDate = DateTime.Now(),
                Deadline = deadline,
                PercentCompleted = 0,
                IsCompleted = false,
            };
            return newTask;
        }
        public static AssignDevTask(AppUser user, DevTask task)
        {
            if(user.Role == "Developer")
            {
                UserDevTask userTask = new UserDevTask
                {
                    AppUserId = user.Id,
                    DevTaskId = task .Id
                };
                user.DevTasks.Add(userTask);
                task.Devs.Add(userTask);
            }
        }
        //Assign 
        public static UpdateDevTask(Task task)
        {
            
        }
        public static DeleteDevTask(Task task)
        {
            db.DevTasks.Delete(task);
        }

        //AddComment(string comment,int taskId) 
        //UpdateCompletionPercent(int newValue, int taskId)
        //SendDeadlineAlert() 
        //SendBugNotification

    }
}