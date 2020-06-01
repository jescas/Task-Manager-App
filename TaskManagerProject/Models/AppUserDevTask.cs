using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskManagerProject.Models
{
    public class AppUserDevTask
    {
        public int? DevTaskId { get; set; }
        [ForeignKey("DevTaskId")]
        public virtual DevTask DevTask { get; set; }
        public int? AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual AppUser AppUser { get; set; }
    }
}