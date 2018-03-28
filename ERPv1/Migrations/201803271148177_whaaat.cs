namespace ERPv1.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class whaaat : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.Waren",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Bezeichnung = c.String(),
                        KurzBezeichnung = c.String(),
                        Notiz = c.String(),
                        Anzahl = c.Int(nullable: false),
                        Preis = c.Double(nullable: false),
                        SteuerKlasse = c.Int(nullable: false),
                        EinzelGewicht = c.Double(nullable: false),
                        ChangedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        SelectedAnzahl = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        ChangedBy_Id = c.String(maxLength: 128),
                        CreatedBy_Id = c.String(maxLength: 128),
                        DeletedBy_Id = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ExtendedWare_Deleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.Waren", "SelectedAnzahl", c => c.Int());
            AddColumn("dbo.Waren", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Waren", "Discriminator");
            DropColumn("dbo.Waren", "SelectedAnzahl");
            AlterTableAnnotations(
                "dbo.Waren",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Bezeichnung = c.String(),
                        KurzBezeichnung = c.String(),
                        Notiz = c.String(),
                        Anzahl = c.Int(nullable: false),
                        Preis = c.Double(nullable: false),
                        SteuerKlasse = c.Int(nullable: false),
                        EinzelGewicht = c.Double(nullable: false),
                        ChangedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        SelectedAnzahl = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        ChangedBy_Id = c.String(maxLength: 128),
                        CreatedBy_Id = c.String(maxLength: 128),
                        DeletedBy_Id = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ExtendedWare_Deleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
        }
    }
}
