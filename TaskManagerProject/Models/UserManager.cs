using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerProject.Models
{
    public class UserManager
    {
        static ApplicationDbContext db = new ApplicationDbContext();

        static UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

        static RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

        public static void CreateUser(string username)
        {
            userManager.Create(new ApplicationUser { UserName = username });
            db.SaveChanges();
        }
        public static void createRole(string roleName)
        {
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole { Name = roleName });
                db.SaveChanges();
            }
        }

        public static void removeRole(string roleName)
        {
            if (roleManager.RoleExists(roleName))
            {
                roleManager.Delete(new IdentityRole { Name = roleName });
            }
        }

        public static bool checkUserRole(string userId, string roleName)
        {
            var result = userManager.IsInRole(userId, roleName);

            return result;
        }

        public static bool AddUserToRole(string userId, string roleName)
        {
            if (checkUserRole(userId, roleName))
            {
                return false;
            }
            else
            {
                userManager.AddToRole(userId, roleName);
                return true;
            }
        }

        public static bool RemoveUserFromRole(string userId, string roleName)
        {
            if (!checkUserRole(userId, roleName))
            {
                return false;
            }
            else
            {
                userManager.RemoveFromRole(userId, roleName);

                return true;
            }
        }
    }
}