namespace ERPv1.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AuftragWarenAdditional : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuftragWaren",
                c => new
                    {
                        AuftragID = c.Guid(nullable: false),
                        WareID = c.Guid(nullable: false),
                        Notiz = c.String(),
                        Menge = c.Int(nullable: false),
                        ChangedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        ChangedBy_Id = c.String(maxLength: 128),
                        CreatedBy_Id = c.String(maxLength: 128),
                        DeletedBy_Id = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AuftragWaren_Deleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => new { t.AuftragID, t.WareID })
                .ForeignKey("dbo.Auftrag", t => t.AuftragID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ChangedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy_Id)
                .ForeignKey("dbo.Waren", t => t.WareID, cascadeDelete: true)
                .Index(t => t.AuftragID)
                .Index(t => t.WareID)
                .Index(t => t.ChangedBy_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.DeletedBy_Id);
            
            AlterTableAnnotations(
                "dbo.Auftrag",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        AuftragsDatum = c.DateTime(nullable: false),
                        RechnungsDatum = c.DateTime(),
                        Notiz = c.String(),
                        Lieferant = c.String(),
                        ChangedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        Bearbeiter_Id = c.String(maxLength: 128),
                        ChangedBy_Id = c.String(maxLength: 128),
                        CreatedBy_Id = c.String(maxLength: 128),
                        DeletedBy_Id = c.String(maxLength: 128),
                        Status_ID = c.Guid(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Auftrag_Deleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Waren",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Bezeichnung = c.String(),
                        KurzBezeichnung = c.String(),
                        Notiz = c.String(),
                        Anzahl = c.Int(nullable: false),
                        Preis = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SteuerKlasse = c.Int(nullable: false),
                        EinzelGewicht = c.Double(nullable: false),
                        ChangedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        ChangedBy_Id = c.String(maxLength: 128),
                        CreatedBy_Id = c.String(maxLength: 128),
                        DeletedBy_Id = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Ware_Deleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.Auftrag", "AuftragsDatum", c => c.DateTime(nullable: false));
            AddColumn("dbo.Auftrag", "RechnungsDatum", c => c.DateTime());
            AddColumn("dbo.Auftrag", "Notiz", c => c.String());
            AddColumn("dbo.Auftrag", "Lieferant", c => c.String());
            AddColumn("dbo.Auftrag", "ChangedOn", c => c.DateTime());
            AddColumn("dbo.Auftrag", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.Auftrag", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Auftrag", "Bearbeiter_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Auftrag", "ChangedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Auftrag", "CreatedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Auftrag", "DeletedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Waren", "Notiz", c => c.String());
            AddColumn("dbo.Waren", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.Waren", "DeletedBy_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Auftrag", "Bearbeiter_Id");
            CreateIndex("dbo.Auftrag", "ChangedBy_Id");
            CreateIndex("dbo.Auftrag", "CreatedBy_Id");
            CreateIndex("dbo.Auftrag", "DeletedBy_Id");
            CreateIndex("dbo.Waren", "DeletedBy_Id");
            AddForeignKey("dbo.Waren", "DeletedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Auftrag", "Bearbeiter_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Auftrag", "ChangedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Auftrag", "CreatedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Auftrag", "DeletedBy_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auftrag", "DeletedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Auftrag", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Auftrag", "ChangedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Auftrag", "Bearbeiter_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Waren", "DeletedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AuftragWaren", "WareID", "dbo.Waren");
            DropForeignKey("dbo.AuftragWaren", "DeletedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AuftragWaren", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AuftragWaren", "ChangedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AuftragWaren", "AuftragID", "dbo.Auftrag");
            DropIndex("dbo.Waren", new[] { "DeletedBy_Id" });
            DropIndex("dbo.AuftragWaren", new[] { "DeletedBy_Id" });
            DropIndex("dbo.AuftragWaren", new[] { "CreatedBy_Id" });
            DropIndex("dbo.AuftragWaren", new[] { "ChangedBy_Id" });
            DropIndex("dbo.AuftragWaren", new[] { "WareID" });
            DropIndex("dbo.AuftragWaren", new[] { "AuftragID" });
            DropIndex("dbo.Auftrag", new[] { "DeletedBy_Id" });
            DropIndex("dbo.Auftrag", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Auftrag", new[] { "ChangedBy_Id" });
            DropIndex("dbo.Auftrag", new[] { "Bearbeiter_Id" });
            DropColumn("dbo.Waren", "DeletedBy_Id");
            DropColumn("dbo.Waren", "DeletedOn");
            DropColumn("dbo.Waren", "Notiz");
            DropColumn("dbo.Auftrag", "DeletedBy_Id");
            DropColumn("dbo.Auftrag", "CreatedBy_Id");
            DropColumn("dbo.Auftrag", "ChangedBy_Id");
            DropColumn("dbo.Auftrag", "Bearbeiter_Id");
            DropColumn("dbo.Auftrag", "CreatedOn");
            DropColumn("dbo.Auftrag", "DeletedOn");
            DropColumn("dbo.Auftrag", "ChangedOn");
            DropColumn("dbo.Auftrag", "Lieferant");
            DropColumn("dbo.Auftrag", "Notiz");
            DropColumn("dbo.Auftrag", "RechnungsDatum");
            DropColumn("dbo.Auftrag", "AuftragsDatum");
            AlterTableAnnotations(
                "dbo.Waren",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Bezeichnung = c.String(),
                        KurzBezeichnung = c.String(),
                        Notiz = c.String(),
                        Anzahl = c.Int(nullable: false),
                        Preis = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SteuerKlasse = c.Int(nullable: false),
                        EinzelGewicht = c.Double(nullable: false),
                        ChangedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        ChangedBy_Id = c.String(maxLength: 128),
                        CreatedBy_Id = c.String(maxLength: 128),
                        DeletedBy_Id = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Ware_Deleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Auftrag",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        AuftragsDatum = c.DateTime(nullable: false),
                        RechnungsDatum = c.DateTime(),
                        Notiz = c.String(),
                        Lieferant = c.String(),
                        ChangedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        Bearbeiter_Id = c.String(maxLength: 128),
                        ChangedBy_Id = c.String(maxLength: 128),
                        CreatedBy_Id = c.String(maxLength: 128),
                        DeletedBy_Id = c.String(maxLength: 128),
                        Status_ID = c.Guid(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Auftrag_Deleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            DropTable("dbo.AuftragWaren",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AuftragWaren_Deleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
