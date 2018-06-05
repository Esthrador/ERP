namespace ERPv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuftragStatusId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Auftrag", name: "Status_ID", newName: "StatusId");
            RenameIndex(table: "dbo.Auftrag", name: "IX_Status_ID", newName: "IX_StatusId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Auftrag", name: "IX_StatusId", newName: "IX_Status_ID");
            RenameColumn(table: "dbo.Auftrag", name: "StatusId", newName: "Status_ID");
        }
    }
}
