namespace ERPv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBearbeiterFromAuftrag : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Auftrag", "Bearbeiter_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Auftrag", new[] { "Bearbeiter_Id" });
            DropColumn("dbo.Auftrag", "Bearbeiter_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Auftrag", "Bearbeiter_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Auftrag", "Bearbeiter_Id");
            AddForeignKey("dbo.Auftrag", "Bearbeiter_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
