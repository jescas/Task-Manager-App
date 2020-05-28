using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerProject.Models
{
    public class UserDevTask
    {
        public int DevTaskId { get; set; }
        public int AppUserId { get; set; }
    }
}