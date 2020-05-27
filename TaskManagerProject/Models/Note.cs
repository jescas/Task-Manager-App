using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerProject.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Read { get; set; }
        public bool Urgent { get; set; }
        public User Recipient { get; set; } //One to Many
        //public User Author { get; set; } // One to Many keep in?
        public virtual Project Project { get; set; } //One to Many 
        public virtual DevTask DevTask { get; set; } // make nullable?
    }
}