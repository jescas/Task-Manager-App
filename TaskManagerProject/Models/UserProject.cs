using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerProject.Models
{
    public class UserProject
    {
        [ForiegnKey("Project")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        [ForeignKey("AppUser")]
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}