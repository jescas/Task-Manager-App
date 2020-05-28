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

        public int GetAllProjects()
        {
            return db.;
        }

        public static void CreateProject(string projectName)
        {
            if (!projectManager.RoleExists(projectName))
            {
                projectManager.Create(new Project { Name = projectName });
            }
        }
        public static void DeleteProject(string projectName)
        {
            if (projectManager.RoleExists(projectName))
            {
                projectManager.Delete(new Project { Name = projectName });
            }
        }
        public static List<string> ProjectsForUser(string userId)
        {
            return userManager.GetRoles(userId).ToList();
        }
    }
}