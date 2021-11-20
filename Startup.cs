using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Payroll_Sys.Models;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(Payroll_Sys.Startup))]
namespace Payroll_Sys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            PopulateUserAndRoles();

        }

        public void PopulateUserAndRoles()
        {
            var db = new ApplicationDbContext();

            if (!db.Roles.Any(x => x.Name == MyConstants.RoleManager))
            {
                db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(MyConstants.RoleManager));
                db.SaveChanges();
            }


            if (!db.Roles.Any(x => x.Name == MyConstants.RoleEmployee))
            {
                db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(MyConstants.RoleEmployee));
                db.SaveChanges();
            }

            //Entering the first user when the program is run with Manager Privileges
            if (!db.Users.Any(x => x.Email == "dumbledore@hogwarts.com"))
            {
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new ApplicationUserManager(userStore);

                var roleStore = new RoleStore<IdentityRole>(db);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var newUser = new ApplicationUser
                {
                    Email = "dumbledore@hogwarts.com",
                    UserName = "dumbledore@hogwarts.com",
                    Firstname = "FNU",
                    Lastname = "Dumbledore"

                };
                
                userManager.Create(newUser, "Qwerty@123");
                userManager.AddToRole(newUser.Id, MyConstants.RoleManager);
                db.SaveChanges();
            }

        }
    }
}
