namespace ERPv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LagerWarenFuerAuftragAufraeumen : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AuftragWaren", "Ware_ID", "dbo.Waren");
            DropIndex("dbo.AuftragWaren", new[] { "Ware_ID" });
            DropColumn("dbo.AuftragWaren", "Ware_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AuftragWaren", "Ware_ID", c => c.Guid());
            CreateIndex("dbo.AuftragWaren", "Ware_ID");
            AddForeignKey("dbo.AuftragWaren", "Ware_ID", "dbo.Waren", "ID");
        }
    }
}
