using Ley22_WebApp_V2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ley22_WebApp_V2.Startup))]
namespace Ley22_WebApp_V2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            CreateUsersAndRoles();
        }

        public void CreateUsersAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("SuperAdmin"))
            {

                var role = new IdentityRole("SuperAdmin");
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "admin@assmca.pr.gov";
                user.Email = "admin@assmca.pr.gov";
                string pwd = "Admin@2018";
                var newuser = userManager.Create(user, pwd);
                if (newuser.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "SuperAdmin");
                }
            }
            if (!roleManager.RoleExists("Supervisor"))
            {
                var role = new IdentityRole("Supervisor");
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Recepcion"))
            {
                var role = new IdentityRole("Recepcion");
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("TrabajadorSocial"))
            {
                var role = new IdentityRole("TrabajadorSocial");
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Recaudador"))
            {
                var role = new IdentityRole("Recaudador");
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("CoordinadorCharlas"))
            {
                var role = new IdentityRole("CoordinadorCharlas");
                roleManager.Create(role);
            }

        }
    }
}
