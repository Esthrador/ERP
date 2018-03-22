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
                Email = "admin@admin.de",
                UserName = "admin@admin.de",
                EmailConfirmed = true,
                FirstName = "Walter",
                LastName = "Röhrich"
            };

            if (userManager.FindByEmail("admin@admin.de") == null)
            {
                userManager.Create(adminUser, "Admin123456#");
                userManager.AddToRole(adminUser.Id, "Administration");
            }

            // Anderweitige Änderungen speichern
            context.SaveChanges();

        }
    }
}
