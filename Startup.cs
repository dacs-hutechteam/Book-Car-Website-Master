using BookCarProjectMaster.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookCarProjectMaster.Startup))]
namespace BookCarProjectMaster
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!roleManager.RoleExists("ADMIN"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "ADMIN";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "admin@gmail.com";
                user.Email = "admin@gmail.com";
                string userPWD = "123456";
                var chkUser = userManager.Create(user, userPWD);
                if (chkUser.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "ADMIN");
                }
            }
            if (!roleManager.RoleExists("MANAGER"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "MANAGER";
                roleManager.Create(role);

                var uManager = new ApplicationUser();
                uManager.UserName = "manager@gmail.com";
                uManager.Email = "manager@gmail.com";
                string UserManagerPWD = "123456";
                var chkUserManager = userManager.Create(uManager, UserManagerPWD);

                if (chkUserManager.Succeeded)
                {
                    var result = userManager.AddToRole(uManager.Id, "MANAGER");
                }

                var userEditor = new ApplicationUser();
                userEditor.UserName = "editor@gmail.com";
                userEditor.Email = "editor@gmail.com";
                string userEditorPWD = "123456";
                var chkUserEditor = userManager.Create(userEditor, userEditorPWD);

                if (chkUserEditor.Succeeded)
                {
                    var result = userManager.AddToRole(userEditor.Id, "MANAGER");
                }
            }
            if (!roleManager.RoleExists("MEMBER"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "MEMBER";
                roleManager.Create(role);
            }
        }
    }
}
