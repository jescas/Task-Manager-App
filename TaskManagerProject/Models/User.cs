using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerProject.Models
{
    public class User : ApplicationUser
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public virtual ICollection<UserProject> Projects { get; set; } //Many to Many
        public virtual ICollection<UserTask> Tasks { get; set; } //Many to Many
        public virtual ICollection<Note> Notes { get; set; } //One to Many
    }
}