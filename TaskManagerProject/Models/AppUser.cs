using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerProject.Models
{
    public class AppUser : ApplicationUser
    {
        public AppUser()
        {
            HashSet<AppUserProject> userProjects = new HashSet<AppUserProject>();
            HashSet<AppUserDevTask> userDevTasks = new HashSet<AppUserDevTask>();
            HashSet<Note> notes = new HashSet<Note>();
            HashSet<Notification> notifications = new HashSet<Notification>();
        }
        public string Name { get; set; }
        public double Salary { get; set; }
        public virtual ICollection<AppUserProject> UserProjects { get; set; } //Many to Many
        public virtual ICollection<AppUserDevTask> UserDevTasks { get; set; } //Many to Many
        public virtual ICollection<Note> Notes { get; set; } //One to Many
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}