using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerProject.Models
{
    public class UserDevTask
    {
        [ForeignKey("DevTask")]
        public int DevTaskId { get; set; }
        public virtual DevTask DevTask { get; set; }
        [ForeignKey("AppUser")]
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}