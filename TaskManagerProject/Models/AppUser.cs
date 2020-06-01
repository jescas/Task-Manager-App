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
            HashSet<UserProject> userProjects = new HashSet<UserProject>();
            HashSet<UserDevTask> userDevTasks = new HashSet<UserDevTask>();
            HashSet<Note> notes = new HashSet<Note>();
            HashSet<Notification> notifications = new HashSet<Notification>();
        }
        public string Name { get; set; }
        public double Salary { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserProject> UserProjects { get; set; } //Many to Many
        [InverseProperty("User")]
        public virtual ICollection<UserDevTask> UserDevTasks { get; set; } //Many to Many
        public virtual ICollection<Note> Notes { get; set; } //One to Many
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}