namespace ERPv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppUserInBaseClassAsString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AuftragWaren", "ChangedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AuftragWaren", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AuftragWaren", "DeletedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Waren", "ChangedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Waren", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Waren", "DeletedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Auftrag", "ChangedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Auftrag", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Auftrag", "DeletedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Kunden", "ChangedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Kunden", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Kunden", "DeletedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Auftrag", new[] { "ChangedBy_Id" });
            DropIndex("dbo.Auftrag", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Auftrag", new[] { "DeletedBy_Id" });
            DropIndex("dbo.AuftragWaren", new[] { "ChangedBy_Id" });
            DropIndex("dbo.AuftragWaren", new[] { "CreatedBy_Id" });
            DropIndex("dbo.AuftragWaren", new[] { "DeletedBy_Id" });
            DropIndex("dbo.Waren", new[] { "ChangedBy_Id" });
            DropIndex("dbo.Waren", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Waren", new[] { "DeletedBy_Id" });
            DropIndex("dbo.Kunden", new[] { "ChangedBy_Id" });
            DropIndex("dbo.Kunden", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Kunden", new[] { "DeletedBy_Id" });
            AddColumn("dbo.Auftrag", "ChangedBy", c => c.String());
            AddColumn("dbo.Auftrag", "CreatedBy", c => c.String());
            AddColumn("dbo.Auftrag", "DeletedBy", c => c.String());
            AddColumn("dbo.AuftragWaren", "ChangedBy", c => c.String());
            AddColumn("dbo.AuftragWaren", "CreatedBy", c => c.String());
            AddColumn("dbo.AuftragWaren", "DeletedBy", c => c.String());
            AddColumn("dbo.Waren", "ChangedBy", c => c.String());
            AddColumn("dbo.Waren", "CreatedBy", c => c.String());
            AddColumn("dbo.Waren", "DeletedBy", c => c.String());
            AddColumn("dbo.Kunden", "ChangedBy", c => c.String());
            AddColumn("dbo.Kunden", "CreatedBy", c => c.String());
            AddColumn("dbo.Kunden", "DeletedBy", c => c.String());
            DropColumn("dbo.Auftrag", "ChangedBy_Id");
            DropColumn("dbo.Auftrag", "CreatedBy_Id");
            DropColumn("dbo.Auftrag", "DeletedBy_Id");
            DropColumn("dbo.AuftragWaren", "ChangedBy_Id");
            DropColumn("dbo.AuftragWaren", "CreatedBy_Id");
            DropColumn("dbo.AuftragWaren", "DeletedBy_Id");
            DropColumn("dbo.Waren", "ChangedBy_Id");
            DropColumn("dbo.Waren", "CreatedBy_Id");
            DropColumn("dbo.Waren", "DeletedBy_Id");
            DropColumn("dbo.Kunden", "ChangedBy_Id");
            DropColumn("dbo.Kunden", "CreatedBy_Id");
            DropColumn("dbo.Kunden", "DeletedBy_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kunden", "DeletedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Kunden", "CreatedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Kunden", "ChangedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Waren", "DeletedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Waren", "CreatedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Waren", "ChangedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AuftragWaren", "DeletedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AuftragWaren", "CreatedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AuftragWaren", "ChangedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Auftrag", "DeletedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Auftrag", "CreatedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Auftrag", "ChangedBy_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Kunden", "DeletedBy");
            DropColumn("dbo.Kunden", "CreatedBy");
            DropColumn("dbo.Kunden", "ChangedBy");
            DropColumn("dbo.Waren", "DeletedBy");
            DropColumn("dbo.Waren", "CreatedBy");
            DropColumn("dbo.Waren", "ChangedBy");
            DropColumn("dbo.AuftragWaren", "DeletedBy");
            DropColumn("dbo.AuftragWaren", "CreatedBy");
            DropColumn("dbo.AuftragWaren", "ChangedBy");
            DropColumn("dbo.Auftrag", "DeletedBy");
            DropColumn("dbo.Auftrag", "CreatedBy");
            DropColumn("dbo.Auftrag", "ChangedBy");
            CreateIndex("dbo.Kunden", "DeletedBy_Id");
            CreateIndex("dbo.Kunden", "CreatedBy_Id");
            CreateIndex("dbo.Kunden", "ChangedBy_Id");
            CreateIndex("dbo.Waren", "DeletedBy_Id");
            CreateIndex("dbo.Waren", "CreatedBy_Id");
            CreateIndex("dbo.Waren", "ChangedBy_Id");
            CreateIndex("dbo.AuftragWaren", "DeletedBy_Id");
            CreateIndex("dbo.AuftragWaren", "CreatedBy_Id");
            CreateIndex("dbo.AuftragWaren", "ChangedBy_Id");
            CreateIndex("dbo.Auftrag", "DeletedBy_Id");
            CreateIndex("dbo.Auftrag", "CreatedBy_Id");
            CreateIndex("dbo.Auftrag", "ChangedBy_Id");
            AddForeignKey("dbo.Kunden", "DeletedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Kunden", "CreatedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Kunden", "ChangedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Auftrag", "DeletedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Auftrag", "CreatedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Auftrag", "ChangedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Waren", "DeletedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Waren", "CreatedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Waren", "ChangedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AuftragWaren", "DeletedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AuftragWaren", "CreatedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AuftragWaren", "ChangedBy_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
