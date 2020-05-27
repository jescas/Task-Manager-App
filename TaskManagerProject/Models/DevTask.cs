using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerProject.Models
{
    public class DevTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        //public DateTime Deadline { get; set; } add in later migration
        public int PercentCompleted { get; set; }
        //enum Priority add in later migration
        public virtual ICollection<string> Comments { get; set; }
        public virtual ICollection<UserDevTask> Devs { get; set; } // Many to Many
        public virtual Project Project { get; set; } //One to Many
        public virtual ICollection<Note> Notes { get; set; }
    }
}