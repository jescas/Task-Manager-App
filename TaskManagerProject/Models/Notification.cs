using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace TaskManagerProject.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isOpened { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int? DevTaskId { get; set; }
        public virtual DevTask DevTask { get; set; }
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}