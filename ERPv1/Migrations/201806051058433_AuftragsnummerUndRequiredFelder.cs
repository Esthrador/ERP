namespace ERPv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuftragsnummerUndRequiredFelder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auftrag", "Auftragsnummer", c => c.Int(nullable: false));
            AlterColumn("dbo.Auftrag", "Bezeichnung", c => c.String(nullable: false));
            AlterColumn("dbo.Auftrag", "RechnungsDatum", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Auftrag", "Lieferant", c => c.String(nullable: false));
            AlterColumn("dbo.Lager", "Bezeichnung", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lager", "Bezeichnung", c => c.String());
            AlterColumn("dbo.Auftrag", "Lieferant", c => c.String());
            AlterColumn("dbo.Auftrag", "RechnungsDatum", c => c.DateTime());
            AlterColumn("dbo.Auftrag", "Bezeichnung", c => c.String());
            DropColumn("dbo.Auftrag", "Auftragsnummer");
        }
    }
}
