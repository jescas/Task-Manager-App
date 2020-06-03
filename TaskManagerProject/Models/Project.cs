using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace TaskManagerProject.Models
{
    public class Project
    {
        public Project()
        {
            HashSet<ApplicationUser> applicationUsers = new HashSet<ApplicationUser>();
            HashSet<DevTask> devTasks = new HashSet<DevTask>();
            HashSet<Notification> notifactions = new HashSet<Notification>();
            HashSet<Note> notes = new HashSet<Note>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        //public DateTime Deadline { get; set; } add in Later migration
        // enum Priority add in later Migration
        public double CompletionPercentage { get; set; }
        public bool IsCompleted = false;
        public double Budget { get; set; }
        public double TotalCost { get; set; }
        public virtual ICollection<DevTask> DevTasks { get; set; } //Many to Many
        public virtual ICollection<Notification> Notifications { get; set; } //One to Many

        public Project(int id, string name, string description, double budget, double totalCost)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.StartDate = DateTime.Now;
            this.CompletionPercentage = 0;
            this.Budget = budget;
            this.TotalCost = totalCost;
        }
    }
}