namespace ERPv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppUserWithName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            DropColumn("dbo.AspNetUsers", "IsAdmin");
            DropColumn("dbo.AspNetUsers", "IsLeiter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IsLeiter", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsAdmin", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
