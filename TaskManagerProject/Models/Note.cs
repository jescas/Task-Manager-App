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
        public virtual Project Project { get; set; } //One to Many 
        public virtual DevTask DevTask { get; set; } 
    }
}