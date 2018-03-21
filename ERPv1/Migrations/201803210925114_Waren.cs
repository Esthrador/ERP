namespace ERPv1.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Waren : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Waren",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Bezeichnung = c.String(),
                        KurzBezeichnung = c.String(),
                        Anzahl = c.Int(nullable: false),
                        ChangedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        Preis = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SteuerKlasse = c.Int(nullable: false),
                        EinzelGewicht = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Waren");
        }
    }
}
