using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace EsbjergCityBackend.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("EsbjergCity", throwIfV1Schema: false)
        {
            Database.SetInitializer(new IdentityDbInit());
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class IdentityDbInit : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new ApplicationUserManager(userStore);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            roleManager.Create(new IdentityRole("Admin"));

            var admin = new ApplicationUser
            {
                UserName = "Admin",
                Email = "admin@admin.dk"
            };
            var user = new ApplicationUser
            {
                UserName = "User",
                Email = "user@user.dk"
            };
            userManager.Create(admin, "Test1!");
            userManager.Create(user, "Test1!");
            userManager.AddToRole(admin.Id, "Admin");
        }
    }
}