namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md213 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SHIPORDERs", "STDCOST", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SHIPORDERs", "STDCOST");
        }
    }
}
