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
        }

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
