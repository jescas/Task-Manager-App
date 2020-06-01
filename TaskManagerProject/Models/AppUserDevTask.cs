using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerProject.Models
{
    public class AppUserDevTask
    {
        public int DevTaskId { get; set; }
        public virtual DevTask DevTask { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}