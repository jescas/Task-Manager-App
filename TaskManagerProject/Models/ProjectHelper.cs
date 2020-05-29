using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerProject.Models
{
    public class ProjectHelper
    {
        public virtual Project Project { get; set; }

        static ApplicationDbContext db = new ApplicationDbContext();

        static UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>
            (new UserStore<ApplicationUser>(db));

        static RoleManager<IdentityRole> projectManager = new RoleManager<IdentityRole>
            (new RoleStore<IdentityRole>(db));

        public List<string> GetAllProjects()
        {
            var result = db.Projects.Select(p => p.Name).ToList();

            return result;
        }

        public static ICollection<int> ProjectsForUser(int userId)
        {
            var result = db.UserProject.Where(up => up.AppUserId == userId).Select(p => p.ProjectId);

            return result.ToList(); 
        }
    }
}