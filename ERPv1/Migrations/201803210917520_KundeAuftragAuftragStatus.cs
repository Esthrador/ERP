namespace ERPv1.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class KundeAuftragAuftragStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auftrag",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Status_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Auftragsstatus", t => t.Status_ID)
                .Index(t => t.Status_ID);
            
            CreateTable(
                "dbo.Auftragsstatus",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Bezeichnung = c.String(),
                        KurzBezeichnung = c.String(),
                        IsVisibleForAll = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
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
                        Gelöscht = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auftrag", "Status_ID", "dbo.Auftragsstatus");
            DropIndex("dbo.Auftrag", new[] { "Status_ID" });
            DropTable("dbo.Kunden");
            DropTable("dbo.Auftragsstatus");
            DropTable("dbo.Auftrag");
        }
    }
}
