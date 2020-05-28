﻿using System;
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
        //public virtual User ProjectManager { get; set; }
        //public virtual Note Note { get; set; }
        //public virtual DevTask DevTask { get; set; }
        //public virtual Project Project { get; set; }
    }
}