namespace ERPv1.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLager : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LagerWaren",
                c => new
                    {
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
                .PrimaryKey(t => new { t.LagerID, t.WareID })
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LagerWaren", "WareID", "dbo.Waren");
            DropForeignKey("dbo.LagerWaren", "LagerID", "dbo.Lager");
            DropIndex("dbo.LagerWaren", new[] { "WareID" });
            DropIndex("dbo.LagerWaren", new[] { "LagerID" });
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
        }
    }
}
