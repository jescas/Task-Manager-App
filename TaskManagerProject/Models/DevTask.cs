using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagerProject.Models
{
    public class DevTask
    {
        public DevTask()
        {
            HashSet<AppUserDevTask> userDevTasks = new HashSet<AppUserDevTask>();
            HashSet<Note> notes = new HashSet<Note>();
            HashSet<Notification> notifications = new HashSet<Notification>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        //public DateTime Deadline { get; set; } add in later migration
        public int PercentCompleted { get; set; }
        public bool IsComplete { get; set; }
        //enum Priority add in later migration
        public virtual ICollection<string> Comments { get; set; }
        public virtual ICollection<AppUserDevTask> UserDevTasks { get; set; } // Many to Many
        public Project Project { get; set; } //One to Many
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Notification> Notification { get; set; }
    }
}