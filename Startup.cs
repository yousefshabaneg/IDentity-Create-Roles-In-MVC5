using IDentity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IDentity.Startup))]
namespace IDentity
{
    public partial class Startup
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
            CreateUsers();
        }

        //note  Defined Some Users To store in AspNetUsers.
        public void CreateUsers()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));

            ApplicationUser user = new ApplicationUser();

            user.Email = "admin@vidly.com";
            user.UserName = "admin@vidly.com";
            var check = userManager.Create(user, "Password*");
            if (check.Succeeded)
                userManager.AddToRole(user.Id, "Admins");
        }



        //note Create Some Roles To store in AspNetRoles.
        public void CreateRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));

            IdentityRole role;

            if (!roleManager.RoleExists("Admins"))
            {
                role = new IdentityRole();
                role.Name = "Admins";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Authors"))
            {
                role = new IdentityRole();
                role.Name = "Authors";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Readers"))
            {
                role = new IdentityRole();
                role.Name = "Readers";
                roleManager.Create(role);
            }

        }
    }
}
