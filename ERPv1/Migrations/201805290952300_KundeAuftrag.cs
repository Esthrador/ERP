namespace ERPv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KundeAuftrag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auftrag", "KundeId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Auftrag", "KundeId");
            AddForeignKey("dbo.Auftrag", "KundeId", "dbo.Kunden", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auftrag", "KundeId", "dbo.Kunden");
            DropIndex("dbo.Auftrag", new[] { "KundeId" });
            DropColumn("dbo.Auftrag", "KundeId");
        }
    }
}
