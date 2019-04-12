using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TutorMeNow.Models;

[assembly: OwinStartupAttribute(typeof(TutorMeNow.Startup))]
namespace TutorMeNow
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
            CreateRoles();

        }

        private void CreateRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Student"))
            {
                var role = new IdentityRole();
                role.Name = "Student";

                roleManager.Create(role);

            }
            if (!roleManager.RoleExists("Tutor"))
            {
                var role = new IdentityRole();
                role.Name = "Tutor";

                roleManager.Create(role);
            }
        }
    }
}
