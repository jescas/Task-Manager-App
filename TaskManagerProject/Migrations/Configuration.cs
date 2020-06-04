namespace TaskManagerProject.Migrations
{
    using TaskManagerProject.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskManagerProject.Models.ApplicationDbContext>
    {
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

            if (!UserManager.checkUserRole("5dce9cdc-8fd3-4118-9282-433e9b3489b5", "Project Manager"))
            {
                ApplicationUser user = context.Users.FirstOrDefault(u => u.UserName == "projectmanager1@mail.com");
                UserManager.AddUserToRole("5dce9cdc-8fd3-4118-9282-433e9b3489b5", "Project Manager");
            }          
            
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
