using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerProject.Models
{
    public class AppUser : ApplicationUser
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; } //Many to Many
        public virtual ICollection<UserDevTask> UserDevTasks { get; set; } //Many to Many
        public virtual ICollection<Note> Notes { get; set; } //One to Many
    }
}