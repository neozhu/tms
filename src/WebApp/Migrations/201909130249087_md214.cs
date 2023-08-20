namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md214 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SHIPORDERs", "GROSSMARGINS", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.SHIPORDERs", "GROSSMARGINSRATE", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SHIPORDERs", "GROSSMARGINSRATE");
            DropColumn("dbo.SHIPORDERs", "GROSSMARGINS");
        }
    }
}
