using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerProject.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        //public DateTime Deadline { get; set; } add in Later migration
        // enum Priority add in later Migration
        public double Budget { get; set; }
        public double TotalCost { get; set; }
        public virtual User ProjectManager { get; set; } //One to Many
        public virtual ICollection<UserProject> Devs { get; set; } //Many to Many
        public virtual ICollection<DevTask> DevTasks { get; set; } //One to Many
        public virtual ICollection<Note> Notes { get; set; } //One to Many
        //public virtual ICollection<Note> SentNotes {get; set; } include?
    }
}