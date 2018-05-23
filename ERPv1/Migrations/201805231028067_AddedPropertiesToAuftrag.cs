namespace ERPv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPropertiesToAuftrag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auftrag", "Bezeichnung", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auftrag", "Bezeichnung");
        }
    }
}
