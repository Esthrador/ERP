namespace ERPv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PreisDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Waren", "Preis", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Waren", "Preis", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
