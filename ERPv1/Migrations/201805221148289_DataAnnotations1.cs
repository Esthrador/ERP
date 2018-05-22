namespace ERPv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kunden", "Vorname", c => c.String(nullable: false));
            AlterColumn("dbo.Kunden", "Nachname", c => c.String(nullable: false));
            AlterColumn("dbo.Kunden", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Kunden", "PLZ", c => c.String(nullable: false));
            AlterColumn("dbo.Kunden", "Ort", c => c.String(nullable: false));
            AlterColumn("dbo.Kunden", "Addresse", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kunden", "Addresse", c => c.String());
            AlterColumn("dbo.Kunden", "Ort", c => c.String());
            AlterColumn("dbo.Kunden", "PLZ", c => c.String());
            AlterColumn("dbo.Kunden", "Email", c => c.String());
            AlterColumn("dbo.Kunden", "Nachname", c => c.String());
            AlterColumn("dbo.Kunden", "Vorname", c => c.String());
        }
    }
}
