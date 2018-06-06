using System;
using System.Linq;
using ERPv1.Models;
using ERPv1.Models.DbContext;
using ERPv1.Models.IdentityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ERPv1.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            
            // Auftragsstati
            if(!context.AuftragStatus.Any(c=>c.Bezeichnung.Equals("Angelegt")))
            {
                var status1 = new AuftragStatus
                {
                    ID = Guid.NewGuid(),
                    Bezeichnung = "Angelegt",
                    KurzBezeichnung = "Angelegt",
                    IsVisibleForAll = true
                };
                context.AuftragStatus.Add(status1);
            }
            if(!context.AuftragStatus.Any(c=>c.Bezeichnung.Equals("Revision")))
            {
                var status1 = new AuftragStatus
                {
                    ID = Guid.NewGuid(),
                    Bezeichnung = "Revision",
                    KurzBezeichnung = "Revision",
                    IsVisibleForAll = true
                };
                context.AuftragStatus.Add(status1);
            }

            if (!context.AuftragStatus.Any(c => c.Bezeichnung.Equals("Beauftragt")))
            {
                var status2 = new AuftragStatus
                {
                    ID = Guid.NewGuid(),
                    Bezeichnung = "Beauftragt",
                    KurzBezeichnung = "Beauftragt",
                    IsVisibleForAll = true
                };
                context.AuftragStatus.Add(status2);
            }

            if (!context.AuftragStatus.Any(c => c.Bezeichnung.Equals("Abgeschlossen")))
            {
                var status3 = new AuftragStatus
                {
                    ID = Guid.NewGuid(),
                    KurzBezeichnung = "Abgeschlossen",
                    Bezeichnung = "Abgeschlossen",
                    IsVisibleForAll = false
                };
                context.AuftragStatus.Add(status3);
            }


            if (!context.AuftragStatus.Any(c => c.Bezeichnung.Equals("Abgerechnet")))
            {
                var status4 = new AuftragStatus
                {
                    ID = Guid.NewGuid(),
                    Bezeichnung = "Abgerechnet",
                    KurzBezeichnung = "Abgerechnet",
                    IsVisibleForAll = false
                };
                context.AuftragStatus.Add(status4);
            }
            
            if (!context.Waren.Any(c => c.ArtikelNummer.Equals("10234587")))
            {
                context.Waren.Add(new Ware
                {
                    ArtikelNummer = "10234587",
                    Anzahl = 1000,
                    Bezeichnung = "Kinder Riegel",
                    KurzBezeichnung = "Kinder Riegel",
                    ID = Guid.NewGuid(),
                    EinzelGewicht = 225,
                    EinzelPreis = 2.99,
                    HerstellerName = "Ferrero",
                    Notiz = "MROEH SUGARZ"
                });
            }
            if (!context.Waren.Any(c => c.ArtikelNummer.Equals("20234587")))
            {
                context.Waren.Add(new Ware
                {
                    ArtikelNummer = "20234587",
                    Anzahl = 1000,
                    Bezeichnung = "Samsung Galaxy S7",
                    KurzBezeichnung = "Samsung Galaxy S7",
                    ID = Guid.NewGuid(),
                    EinzelGewicht = 225,
                    EinzelPreis = 700.99,
                    HerstellerName = "Samsung",
                    Notiz = "Gib Phonez"
                });
            }
            if (!context.Waren.Any(c => c.ArtikelNummer.Equals("30123476")))
            {
                context.Waren.Add(new Ware
                {
                    ArtikelNummer = "30123476",
                    Anzahl = 1000,
                    Bezeichnung = "Kingston DDR3-RAM 4GB 1866MHz",
                    KurzBezeichnung = "4GB RAM",
                    ID = Guid.NewGuid(),
                    EinzelGewicht = 225,
                    EinzelPreis = 299,
                    HerstellerName = "Kingston",
                    Notiz = "Gief RAM plox :DDd"
                });
            }
            if (!context.Waren.Any(c => c.ArtikelNummer.Equals("51678301")))
            {
                context.Waren.Add(new Ware
                {
                    ArtikelNummer = "51678301",
                    Anzahl = 1000,
                    Bezeichnung = "Lucky Strike Big Pack",
                    KurzBezeichnung = "Lucky Strike ",
                    ID = Guid.NewGuid(),
                    EinzelGewicht = 225,
                    EinzelPreis = 6.5,
                    HerstellerName = "BAT",
                    Notiz = "Hust hust"
                });
            }
            if (!context.Waren.Any(c => c.ArtikelNummer.Equals("66601337")))
            {
                context.Waren.Add(new Ware
                {
                    ArtikelNummer = "66601337",
                    Anzahl = 1000,
                    Bezeichnung = "Necronomicon",
                    KurzBezeichnung = "Necronomicon",
                    ID = Guid.NewGuid(),
                    EinzelGewicht = 225,
                    EinzelPreis = 100,
                    HerstellerName = "Illuminati",
                    Notiz = "MROEH DVEILZ"
                });
            }

            if (!context.Lager.Any())
            {
                context.Lager.Add(new Lager
                {
                    Bezeichnung = "Hauptlager",
                    ID = Guid.NewGuid(),
                    Adresse = "Strasse 1",
                    Ort = "Hamburg",
                    PLZ = "22022",
                    Standort = "Hamburg Süd"
                });
                context.Lager.Add(new Lager
                {
                    Bezeichnung = "Nebenlager",
                    ID = Guid.NewGuid(),
                    Adresse = "Strasse 1",
                    Ort = "Reinbek",
                    PLZ = "21465",
                    Standort = "Hamburg Ost"
                });
            }

            var now = DateTime.Now.Month;
            if (!context.Kunden.Any(c => c.CreatedOn.Month < now))
            {
                context.Kunden.Add(new Kunde
                {
                    ID = Guid.NewGuid(),
                    KurzBezeichnung = "Erster Kunde",
                    Vorname = "Hans",
                    Nachname = "Meiser",
                    PLZ = "01234",
                    Ort = "Duisburg",
                    Addresse = "Strasse 1",
                    Email = "a@a.a",
                    Tel = "04043218765",
                    CreatedOn = new DateTime(2018,4,23)
                });
                context.Kunden.Add(new Kunde
                {
                    ID = Guid.NewGuid(),
                    KurzBezeichnung = "Zweiter Kunde",
                    Vorname = "Horst",
                    Nachname = "Seehofer",
                    PLZ = "81234",
                    Ort = "München",
                    Addresse = "Strasse 1",
                    Email = "a@a.a",
                    Tel = "04043218765",
                    CreatedOn = new DateTime(2018,4,26)
                });
                context.Kunden.Add(new Kunde
                {
                    ID = Guid.NewGuid(),
                    KurzBezeichnung = "Dritter Kunde",
                    Vorname = "Deutsche Bank",
                    Nachname = "..",
                    IsFirma = true,
                    PLZ = "41234",
                    Ort = "Frankfurt",
                    Addresse = "Strasse 1",
                    Email = "a@a.a",
                    Tel = "04043218765",
                    CreatedOn = new DateTime(2018,5,3)
                });
                context.Kunden.Add(new Kunde
                {
                    ID = Guid.NewGuid(),
                    KurzBezeichnung = "Vierter Kunde",
                    Vorname = "Röhrich & Co. Sanitärbetriebe GmbH",
                    Nachname = "..",
                    PLZ = "24234",
                    Ort = "Husum",
                    Addresse = "Strasse 1",
                    IsFirma = true,
                    Email = "a@a.a",
                    Tel = "04043218765",
                    CreatedOn = new DateTime(2018,5,3)
                });
                context.Kunden.Add(new Kunde
                {
                    ID = Guid.NewGuid(),
                    KurzBezeichnung = "Fünfter Kunde",
                    Vorname = "Hans",
                    Nachname = "Meiser",
                    PLZ = "01234",
                    Ort = "Halle",
                    Addresse = "Strasse 1",
                    Email = "a@a.a",
                    Tel = "04043218765",
                    CreatedOn = new DateTime(2018,5,12)
                });
                context.Kunden.Add(new Kunde
                {
                    ID = Guid.NewGuid(),
                    KurzBezeichnung = "Sechster Kunde",
                    Vorname = "Reinhardt",
                    Nachname = "Köchler",
                    PLZ = "21465",
                    Ort = "Reinbek",
                    Addresse = "Strasse 1",
                    Email = "a@a.a",
                    Tel = "04043218765",
                    CreatedOn = new DateTime(2018,5,26)
                });
                context.Kunden.Add(new Kunde
                {
                    ID = Guid.NewGuid(),
                    KurzBezeichnung = "Siebter Kunde",
                    Vorname = "Soul Kebap",
                    Nachname = "..",
                    IsFirma = true,
                    PLZ = "01234",
                    Ort = "Duisburg",
                    Addresse = "Strasse 1",
                    Email = "a@a.a",
                    Tel = "04043218765",
                    CreatedOn = new DateTime(2018,6,3)
                });
                context.Kunden.Add(new Kunde
                {
                    ID = Guid.NewGuid(),
                    KurzBezeichnung = "Achter Kunde",
                    Vorname = "Timo",
                    Nachname = "Sattler",
                    PLZ = "21031",
                    Ort = "Hamburg",
                    Addresse = "Binnenfeldredder 30",
                    Email = "a@a.a",
                    Tel = "04043218765",
                    CreatedOn = new DateTime(2018,6,4)
                });
            }



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
                userManager.Create(mitarbeiter1User, "Pw123456#");
                userManager.AddToRole(mitarbeiter1User.Id, "Mitarbeiter");
            }



            // Anderweitige Änderungen speichern
            context.SaveChanges();

        }
    }
}
