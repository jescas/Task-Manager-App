using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManagerProject.Models
{
    [Authorize(Roles = "ProjectManager")]
    public class ProjectHelper
    {
        static ApplicationDbContext db = new ApplicationDbContext();
        public ICollection<Project> GetAllProjects()
        {
            var result = db.Projects.ToList();

            return result;
        }

        public ICollection<string> ProjectsForUser(int userId)
        {
            var result = db.Projects.Where(up => up.Id == userId).Select(p => p.Name);
            return result.ToList();
        }

        public void AddProject(int projectId)
        {
            var project = db.Projects.FirstOrDefault(p=>p.Id == projectId);

            if (project.Id != projectId)
            {
                db.Projects.Add(project);

                db.SaveChanges();
            }
            else
            {
                throw new Exception("Project Already Exists");
            }
        }

        public void DeleteProject(Project projectId)
        {
            if (!db.Projects.Contains(projectId))
            {
                db.Projects.Remove(projectId);
            }
            else
            {
                throw new Exception("Project Does Not Exist");
            }
        }
    }
}