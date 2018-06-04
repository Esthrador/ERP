namespace ERPv1.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditLogs",
                c => new
                    {
                        AuditLogId = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        EventDateUTC = c.DateTime(nullable: false),
                        EventType = c.Int(nullable: false),
                        TypeFullName = c.String(nullable: false, maxLength: 512),
                        RecordId = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.AuditLogId);
            
            CreateTable(
                "dbo.AuditLogDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PropertyName = c.String(nullable: false, maxLength: 256),
                        OriginalValue = c.String(),
                        NewValue = c.String(),
                        AuditLogId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuditLogs", t => t.AuditLogId, cascadeDelete: true)
                .Index(t => t.AuditLogId);
            
            CreateTable(
                "dbo.LogMetadata",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AuditLogId = c.Long(nullable: false),
                        Key = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuditLogs", t => t.AuditLogId, cascadeDelete: true)
                .Index(t => t.AuditLogId);
            
            CreateTable(
                "dbo.Auftrag",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Bezeichnung = c.String(),
                        AuftragsDatum = c.DateTime(nullable: false),
                        RechnungsDatum = c.DateTime(),
                        Notiz = c.String(),
                        Lieferant = c.String(),
                        KundeId = c.Guid(nullable: false),
                        ChangedBy = c.String(),
                        CreatedBy = c.String(),
                        DeletedBy = c.String(),
                        ChangedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        Bearbeiter_Id = c.String(maxLength: 128),
                        Status_ID = c.Guid(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Auftrag_Deleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.Bearbeiter_Id)
                .ForeignKey("dbo.Kunden", t => t.KundeId, cascadeDelete: true)
                .ForeignKey("dbo.Auftragsstatus", t => t.Status_ID)
                .Index(t => t.KundeId)
                .Index(t => t.Bearbeiter_Id)
                .Index(t => t.Status_ID);
            
            CreateTable(
                "dbo.AuftragWaren",
                c => new
                    {
                        AuftragWarenID = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        AuftragID = c.Guid(nullable: false),
                        WareID = c.Guid(nullable: false),
                        Notiz = c.String(),
                        Menge = c.Int(nullable: false),
                        ChangedBy = c.String(),
                        CreatedBy = c.String(),
                        DeletedBy = c.String(),
                        ChangedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AuftragWaren_Deleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.AuftragWarenID)
                .ForeignKey("dbo.Auftrag", t => t.AuftragID, cascadeDelete: true)
                .ForeignKey("dbo.Waren", t => t.WareID, cascadeDelete: true)
                .Index(t => t.AuftragID)
                .Index(t => t.WareID);
            
            CreateTable(
                "dbo.Waren",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ArtikelNummer = c.String(nullable: false, maxLength: 32),
                        Bezeichnung = c.String(nullable: false),
                        KurzBezeichnung = c.String(),
                        HerstellerName = c.String(nullable: false, maxLength: 32),
                        DeletedOn = c.DateTime(),
                        Anzahl = c.Int(nullable: false),
                        EinzelPreis = c.Double(nullable: false),
                        EinzelGewicht = c.Double(nullable: false),
                        Notiz = c.String(),
                        ChangedBy = c.String(),
                        CreatedBy = c.String(),
                        DeletedBy = c.String(),
                        ChangedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Ware_Deleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.ID)
                .Index(t => new { t.ArtikelNummer, t.HerstellerName, t.DeletedOn }, unique: true, name: "IX_ArtNr_Hersteller_Delete");
            
            CreateTable(
                "dbo.LagerWaren",
                c => new
                    {
                        LagerWarenID = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        LagerID = c.Guid(nullable: false),
                        WareID = c.Guid(nullable: false),
                        Menge = c.Int(nullable: false),
                        ChangedBy = c.String(),
                        CreatedBy = c.String(),
                        DeletedBy = c.String(),
                        ChangedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LagerWaren_Deleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.LagerWarenID)
                .ForeignKey("dbo.Lager", t => t.LagerID, cascadeDelete: true)
                .ForeignKey("dbo.Waren", t => t.WareID, cascadeDelete: true)
                .Index(t => t.LagerID)
                .Index(t => t.WareID);
            
            CreateTable(
                "dbo.Lager",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Bezeichnung = c.String(),
                        Standort = c.String(nullable: false),
                        Adresse = c.String(nullable: false),
                        PLZ = c.String(nullable: false),
                        Ort = c.String(nullable: false),
                        ChangedBy = c.String(),
                        CreatedBy = c.String(),
                        DeletedBy = c.String(),
                        ChangedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Lager_Deleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Kunden",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Vorname = c.String(nullable: false),
                        Nachname = c.String(nullable: false),
                        IsFirma = c.Boolean(nullable: false),
                        Email = c.String(nullable: false),
                        PLZ = c.String(nullable: false),
                        Ort = c.String(nullable: false),
                        Addresse = c.String(nullable: false),
                        Tel = c.String(),
                        KurzBezeichnung = c.String(),
                        ChangedBy = c.String(),
                        CreatedBy = c.String(),
                        DeletedBy = c.String(),
                        ChangedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Kunde_Deleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Auftragsstatus",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Bezeichnung = c.String(),
                        KurzBezeichnung = c.String(),
                        IsVisibleForAll = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Auftrag", "Status_ID", "dbo.Auftragsstatus");
            DropForeignKey("dbo.Auftrag", "KundeId", "dbo.Kunden");
            DropForeignKey("dbo.Auftrag", "Bearbeiter_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AuftragWaren", "WareID", "dbo.Waren");
            DropForeignKey("dbo.LagerWaren", "WareID", "dbo.Waren");
            DropForeignKey("dbo.LagerWaren", "LagerID", "dbo.Lager");
            DropForeignKey("dbo.AuftragWaren", "AuftragID", "dbo.Auftrag");
            DropForeignKey("dbo.LogMetadata", "AuditLogId", "dbo.AuditLogs");
            DropForeignKey("dbo.AuditLogDetails", "AuditLogId", "dbo.AuditLogs");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.LagerWaren", new[] { "WareID" });
            DropIndex("dbo.LagerWaren", new[] { "LagerID" });
            DropIndex("dbo.Waren", "IX_ArtNr_Hersteller_Delete");
            DropIndex("dbo.AuftragWaren", new[] { "WareID" });
            DropIndex("dbo.AuftragWaren", new[] { "AuftragID" });
            DropIndex("dbo.Auftrag", new[] { "Status_ID" });
            DropIndex("dbo.Auftrag", new[] { "Bearbeiter_Id" });
            DropIndex("dbo.Auftrag", new[] { "KundeId" });
            DropIndex("dbo.LogMetadata", new[] { "AuditLogId" });
            DropIndex("dbo.AuditLogDetails", new[] { "AuditLogId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Auftragsstatus");
            DropTable("dbo.Kunden",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Kunde_Deleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Lager",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Lager_Deleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.LagerWaren",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LagerWaren_Deleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Waren",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Ware_Deleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AuftragWaren",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AuftragWaren_Deleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Auftrag",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Auftrag_Deleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.LogMetadata");
            DropTable("dbo.AuditLogDetails");
            DropTable("dbo.AuditLogs");
        }
    }
}
