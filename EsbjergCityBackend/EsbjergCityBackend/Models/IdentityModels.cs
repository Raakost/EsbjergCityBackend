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

    public class IdentityDbInit : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new ApplicationUserManager(userStore);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            roleManager.Create(new IdentityRole("Admin"));
            roleManager.Create(new IdentityRole("User"));

            var admin1 = new ApplicationUser
            {
                UserName = "Brigitta",
                Email = "brigitta@esbjergcity.dk"
            };
            var admin2 = new ApplicationUser
            {
                UserName = "Ingelise",
                Email = "ingelise@esbjergcity.dk"
            };
            userManager.Create(admin1, "Test1!");
            userManager.Create(admin2, "Test1!");
            userManager.AddToRole(admin1.Id, "Admin");
            userManager.AddToRole(admin2.Id, "Admin");
        }
    }
}