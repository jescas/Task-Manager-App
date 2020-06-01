using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TaskManagerProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public class AppUser
        {
            public AppUser()
            {
                HashSet<Project> projects = new HashSet<Project>();
                HashSet<DevTask> devTasks = new HashSet<DevTask>();
                HashSet<Note> notes = new HashSet<Note>();
                HashSet<Notification> notifications = new HashSet<Notification>();
            }
            public double Salary { get; set; }
            public virtual ICollection<Project> Projects { get; set; } //Many to Many
            public virtual ICollection<DevTask> DevTasks { get; set; } //Many to Many
            public virtual ICollection<Note> Notes { get; set; } //One to Many
            public virtual ICollection<Notification> Notifications { get; set; }
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<DevTask> DevTasks { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ProjectHelper> ProjectHelpers { get; set; }
        public DbSet<UserManager> UserManagers { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}