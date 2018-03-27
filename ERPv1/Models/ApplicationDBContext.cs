using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EntityFramework.DynamicFilters;
using ERPv1.Migrations;
using Microsoft.AspNet.Identity;
using TrackerEnabledDbContext.Identity;

namespace ERPv1.Models
{
    public class ApplicationDbContext : TrackerIdentityContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<AuftragStatus> AuftragStatus { get; set; }
        public DbSet<Auftrag> Auftrag { get; set; }
        public DbSet<Ware> Waren { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            ApplicationUser au = null;
            var entries = ChangeTracker.Entries().Where(c => c.Entity is BaseClass && c.State == EntityState.Added 
                                                             || c.State == EntityState.Deleted || c.State == EntityState.Modified);
            var currentUserId = HttpContext.Current?.User.Identity.GetUserId();
            if (currentUserId != null)
            {
                au = this.Users.Find(HttpContext.Current?.User.Identity.GetUserId());
            }

           // if (au == null) base.SaveChanges();

            foreach (var e in entries)
            {
                if (e.State == EntityState.Added)
                {
                    ((BaseClass) e.Entity).CreatedBy = au;
                    ((BaseClass) e.Entity).CreatedOn = DateTime.Now;
                }
                if (e.State == EntityState.Deleted)
                {
                    ((BaseClass) e.Entity).DeletedOn = DateTime.Now;
                    ((BaseClass) e.Entity).DeletedBy = au;
                    e.State = EntityState.Modified;
                }


                ((BaseClass) e.Entity).ChangedBy = au;
                ((BaseClass) e.Entity).ChangedOn = DateTime.Now;
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Filter("Deleted", (BaseClass c) => !c.DeletedOn.HasValue);
            base.OnModelCreating(modelBuilder);
        }
    }
}