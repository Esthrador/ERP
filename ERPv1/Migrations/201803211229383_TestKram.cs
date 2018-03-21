namespace ERPv1.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class TestKram : DbMigration
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
            
            AlterTableAnnotations(
                "dbo.Kunden",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Vorname = c.String(),
                        Nachname = c.String(),
                        IsFirma = c.Boolean(nullable: false),
                        Email = c.String(),
                        PLZ = c.String(),
                        Ort = c.String(),
                        Addresse = c.String(),
                        Tel = c.String(),
                        KurzBezeichnung = c.String(),
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
                        "DynamicFilter_Kunde_Deleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.Kunden", "ChangedOn", c => c.DateTime());
            AddColumn("dbo.Kunden", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.Kunden", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Kunden", "ChangedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Kunden", "CreatedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Kunden", "DeletedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "IsAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsLeiter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Waren", "ChangedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Waren", "CreatedBy_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Kunden", "ChangedBy_Id");
            CreateIndex("dbo.Kunden", "CreatedBy_Id");
            CreateIndex("dbo.Kunden", "DeletedBy_Id");
            CreateIndex("dbo.Waren", "ChangedBy_Id");
            CreateIndex("dbo.Waren", "CreatedBy_Id");
            AddForeignKey("dbo.Kunden", "ChangedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Kunden", "CreatedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Kunden", "DeletedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Waren", "ChangedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Waren", "CreatedBy_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Kunden", "Gelöscht");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kunden", "Gelöscht", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Waren", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Waren", "ChangedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Kunden", "DeletedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Kunden", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Kunden", "ChangedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.LogMetadata", "AuditLogId", "dbo.AuditLogs");
            DropForeignKey("dbo.AuditLogDetails", "AuditLogId", "dbo.AuditLogs");
            DropIndex("dbo.Waren", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Waren", new[] { "ChangedBy_Id" });
            DropIndex("dbo.Kunden", new[] { "DeletedBy_Id" });
            DropIndex("dbo.Kunden", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Kunden", new[] { "ChangedBy_Id" });
            DropIndex("dbo.LogMetadata", new[] { "AuditLogId" });
            DropIndex("dbo.AuditLogDetails", new[] { "AuditLogId" });
            DropColumn("dbo.Waren", "CreatedBy_Id");
            DropColumn("dbo.Waren", "ChangedBy_Id");
            DropColumn("dbo.AspNetUsers", "IsLeiter");
            DropColumn("dbo.AspNetUsers", "IsAdmin");
            DropColumn("dbo.Kunden", "DeletedBy_Id");
            DropColumn("dbo.Kunden", "CreatedBy_Id");
            DropColumn("dbo.Kunden", "ChangedBy_Id");
            DropColumn("dbo.Kunden", "CreatedOn");
            DropColumn("dbo.Kunden", "DeletedOn");
            DropColumn("dbo.Kunden", "ChangedOn");
            AlterTableAnnotations(
                "dbo.Kunden",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Vorname = c.String(),
                        Nachname = c.String(),
                        IsFirma = c.Boolean(nullable: false),
                        Email = c.String(),
                        PLZ = c.String(),
                        Ort = c.String(),
                        Addresse = c.String(),
                        Tel = c.String(),
                        KurzBezeichnung = c.String(),
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
                        "DynamicFilter_Kunde_Deleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            DropTable("dbo.LogMetadata");
            DropTable("dbo.AuditLogDetails");
            DropTable("dbo.AuditLogs");
        }
    }
}
