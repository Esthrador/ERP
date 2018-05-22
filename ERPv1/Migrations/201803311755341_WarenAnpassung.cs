namespace ERPv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WarenAnpassung : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Waren", "ArtikelNummer", c => c.String(nullable: false, maxLength: 32));
            AddColumn("dbo.Waren", "HerstellerName", c => c.String(nullable: false, maxLength: 32));
            AddColumn("dbo.Waren", "EinzelPreis", c => c.Double(nullable: false));
            AlterColumn("dbo.Waren", "Bezeichnung", c => c.String(nullable: false));
            CreateIndex("dbo.Waren", new[] { "ArtikelNummer", "HerstellerName" }, unique: true, name: "ArtNr_Hersteller_Index");
            DropColumn("dbo.Waren", "Preis");
            DropColumn("dbo.Waren", "SteuerKlasse");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Waren", "SteuerKlasse", c => c.Int(nullable: false));
            AddColumn("dbo.Waren", "Preis", c => c.Double(nullable: false));
            DropIndex("dbo.Waren", "ArtNr_Hersteller_Index");
            AlterColumn("dbo.Waren", "Bezeichnung", c => c.String());
            DropColumn("dbo.Waren", "EinzelPreis");
            DropColumn("dbo.Waren", "HerstellerName");
            DropColumn("dbo.Waren", "ArtikelNummer");
        }
    }
}
