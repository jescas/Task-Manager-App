namespace TaskManagerProject.Migrations
{
    using TaskManagerProject.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
 
    internal sealed class Configuration : DbMigrationsConfiguration<TaskManagerProject.Models.ApplicationDbContext>
    {
        public DevTaskHelper dth = new DevTaskHelper();
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

            if (!context.DevTasks.Any())
            {
                DevTask taskOne = dth.CreateDevTask(1, "TaskOneInFirstProject", "First class of first project", DateTime.Parse("02/02/2024"), context.Projects.FirstOrDefault().Id);
                DevTask taskTwo = dth.CreateDevTask(2, "TaskTwoInFirstProject", "Second class of first project", DateTime.Parse("02/02/2015"), context.Projects.FirstOrDefault().Id);
                DevTask taskThree = dth.CreateDevTask(3,"TaskThreeInFirstProject", "Third class of first project", DateTime.Parse("02/02/2016"), context.Projects.FirstOrDefault().Id);
                DevTask taskFour = dth.CreateDevTask(4,"TaskFourinFirstProject", "Fourth class of first project", DateTime.Parse("02/02/2027"), context.Projects.FirstOrDefault().Id);

                context.DevTasks.Add(taskOne);
                context.DevTasks.Add(taskTwo);
                context.DevTasks.Add(taskThree);
                context.DevTasks.Add(taskFour);
            }
            DevTask firstTask = context.DevTasks.FirstOrDefault();
            if (!context.Projects.ToList()[1].DevTasks.Any())
            {

                DevTask taskOne = dth.CreateDevTask(5,"TaskOneInSecondProject", "First class of second project", DateTime.Parse("02/02/2024"), context.Projects.ToList()[1].Id);
                DevTask taskTwo = dth.CreateDevTask(6,"TaskTwoInSecondProject", "Second class of second project", DateTime.Parse("02/02/2015"), context.Projects.ToList()[1].Id);
                DevTask taskThree = dth.CreateDevTask(7,"TaskOneInThirdProject", "First class of third project", DateTime.Parse("02/02/2024"), context.Projects.ToList()[2].Id);
                DevTask taskFour = dth.CreateDevTask(8,"TaskTwoInThirdProject", "Second class of third project", DateTime.Parse("02/02/2015"), context.Projects.ToList()[2].Id);
                DevTask taskFive = dth.CreateDevTask(9,"TaskOneInFourthProject", "First class of fourth project", DateTime.Parse("02/02/2024"), context.Projects.ToList()[3].Id);
                DevTask taskSix = dth.CreateDevTask(10,"TaskTwoInFourthProject", "Second class of fourth project", DateTime.Parse("02/02/2015"), context.Projects.ToList()[3].Id);

                context.DevTasks.Add(taskOne);
                context.DevTasks.Add(taskTwo);
                context.DevTasks.Add(taskThree);
                context.DevTasks.Add(taskFour);
                context.DevTasks.Add(taskFive);
                context.DevTasks.Add(taskSix);
            }

            if (!context.Notifications.Any())
            {
                //Notification notificationOne = dth.SendNotification("Notification1", "first in user 1 and task 1", context.Users.First(), firstTask);

            }
            //Notes
            
            //if (firstTask.ApplicationUsers.Count() <= 0)
            //{
            //    DevTaskHelper.AssignDevsToTask(context.Users.ToList(), firstTask);
            //};
            
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
