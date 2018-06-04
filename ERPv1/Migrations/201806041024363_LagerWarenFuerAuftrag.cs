namespace ERPv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LagerWarenFuerAuftrag : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AuftragWaren", "WareID", "dbo.Waren");
            DropIndex("dbo.AuftragWaren", new[] { "WareID" });
            RenameColumn(table: "dbo.AuftragWaren", name: "WareID", newName: "Ware_ID");
            AddColumn("dbo.AuftragWaren", "LagerWareID", c => c.Guid(nullable: false));
            AlterColumn("dbo.AuftragWaren", "Ware_ID", c => c.Guid());
            CreateIndex("dbo.AuftragWaren", "LagerWareID");
            CreateIndex("dbo.AuftragWaren", "Ware_ID");
            AddForeignKey("dbo.AuftragWaren", "LagerWareID", "dbo.LagerWaren", "LagerWarenID", cascadeDelete: true);
            AddForeignKey("dbo.AuftragWaren", "Ware_ID", "dbo.Waren", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuftragWaren", "Ware_ID", "dbo.Waren");
            DropForeignKey("dbo.AuftragWaren", "LagerWareID", "dbo.LagerWaren");
            DropIndex("dbo.AuftragWaren", new[] { "Ware_ID" });
            DropIndex("dbo.AuftragWaren", new[] { "LagerWareID" });
            AlterColumn("dbo.AuftragWaren", "Ware_ID", c => c.Guid(nullable: false));
            DropColumn("dbo.AuftragWaren", "LagerWareID");
            RenameColumn(table: "dbo.AuftragWaren", name: "Ware_ID", newName: "WareID");
            CreateIndex("dbo.AuftragWaren", "WareID");
            AddForeignKey("dbo.AuftragWaren", "WareID", "dbo.Waren", "ID", cascadeDelete: true);
        }
    }
}
