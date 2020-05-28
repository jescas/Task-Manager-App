﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerProject.Models
{
    public class DevTask
    {
        public DevTask()
        {
            HashSet<UserDevTask> userDevTasks = new HashSet<UserDevTask>();
            HashSet<Note> notes = new HashSet<Note>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        //public DateTime Deadline { get; set; } add in later migration
        public int PercentCompleted { get; set; }
        public bool IsComplete { get; set; }
        //enum Priority add in later migration
        public virtual ICollection<string> Comments { get; set; }
        public virtual ICollection<UserDevTask> UserDevTaskss{ get; set; } // Many to Many
        public Project Project { get; set; } //One to Many
        public virtual ICollection<Note> Notes { get; set; }
    }
}