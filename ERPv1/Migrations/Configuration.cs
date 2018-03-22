using ERPv1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ERPv1.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
            
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());

            // Rollen erzeugen
            if (!roleManager.RoleExists("Administration"))
                roleManager.Create(new IdentityRole("Administration"));

            if (!roleManager.RoleExists("Abteilungsleiter"))
                roleManager.Create(new IdentityRole("Abteilungsleiter"));

            if (!roleManager.RoleExists("Mitarbeiter"))
                roleManager.Create(new IdentityRole("Mitarbeiter"));

            // User erzeugen
            var adminUser = new ApplicationUser
            {
                Email = "admin@erp.de",
                UserName = "admin@erp.de",
                EmailConfirmed = true,
                FirstName = "Walter",
                LastName = "Röhrich"
            };

            var leiter1User = new ApplicationUser
            {
                Email = "abteilungsleiter1@erp.de",
                UserName = "abteilungsleiter1@erp.de",
                EmailConfirmed = true,
                FirstName = "Werner",
                LastName = "Eckhardt"
            };

            var mitarbeiter1User = new ApplicationUser
            {
                Email = "mitarbeiter1@erp.de",
                UserName = "mitarbeiter1@erp.de",
                EmailConfirmed = true,
                FirstName = "Andi",
                LastName = "Feldmann"
            };

            if (userManager.FindByEmail("admin@erp.de") == null)
            {
                userManager.Create(adminUser, "Pw123456#");
                userManager.AddToRole(adminUser.Id, "Administration");
            }

            if (userManager.FindByEmail("abteilungsleiter1@erp.de") == null)
            {
                userManager.Create(leiter1User, "Pw123456#");
                userManager.AddToRole(leiter1User.Id, "Abteilungsleiter");
            }

            if (userManager.FindByEmail("mitarbeiter1@erp.de") == null)
            {
                userManager.Create(adminUser, "Pw123456#");
                userManager.AddToRole(adminUser.Id, "Mitarbeiter");
            }

            // Anderweitige Änderungen speichern
            context.SaveChanges();

        }
    }
}
