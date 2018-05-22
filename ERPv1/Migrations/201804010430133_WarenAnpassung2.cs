namespace ERPv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WarenAnpassung2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Waren", "ArtNr_Hersteller_Index");
            CreateIndex("dbo.Waren", new[] { "ArtikelNummer", "HerstellerName", "DeletedOn" }, unique: true, name: "IX_ArtNr_Hersteller_Delete");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Waren", "IX_ArtNr_Hersteller_Delete");
            CreateIndex("dbo.Waren", new[] { "ArtikelNummer", "HerstellerName" }, unique: true, name: "ArtNr_Hersteller_Index");
        }
    }
}
