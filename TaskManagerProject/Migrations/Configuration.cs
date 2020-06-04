namespace TaskManagerProject.Migrations
{
    using TaskManagerProject.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskManagerProject.Models.ApplicationDbContext>
    {

        public ProjectHelper ph = new ProjectHelper();
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaskManagerProject.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            if (!context.Roles.Any())
            {
                UserManager.createRole("Project Manager");
                UserManager.createRole("Developer");
            }

            if (!context.Users.Any())
            {
                UserManager.CreateUser("projectmanager1@mail.com");
                UserManager.CreateUser("developer1@mail.com");
            }

            string PmId = context.Users.FirstOrDefault().Id;

            if (!UserManager.checkUserRole(PmId, "Project Manager"))
            {
                ApplicationUser user = context.Users.FirstOrDefault(u => u.UserName == "projectmanager1@mail.com");

                UserManager.AddUserToRole(PmId, "Project Manager");
            }

            string DeId = context.Users.FirstOrDefault().Id;

            if (!UserManager.checkUserRole(DeId, "Developer"))
            {
                ApplicationUser user = context.Users.FirstOrDefault(u => u.UserName == "developer1@mail.com");

                UserManager.AddUserToRole(DeId, "Developer");
            }

            if (!context.Projects.Any())
            {
                Project firstProject = new Project(1, "firstProject", "Our first test project", 100.00, 95.00);
                Project secondProject = new Project(2, "secondProject", "Our second test project", 500.00, 600.00);
                Project thirdProject = new Project(3, "thirdProject", "Our third test project", 250.00, 275.00);
                Project fourthProject = new Project(4, "fourthProject", "Our fourth test project", 150.00, 130.00);

                context.Projects.Add(firstProject);
                context.Projects.Add(secondProject);
                context.Projects.Add(thirdProject);
                context.Projects.Add(fourthProject);
            }

            

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
