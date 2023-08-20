namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md1006 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LocBases", "Longitude1", c => c.Decimal(nullable: false, precision: 18, scale: 8));
            AddColumn("dbo.LocBases", "Latitude1", c => c.Decimal(nullable: false, precision: 18, scale: 8));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LocBases", "Latitude1");
            DropColumn("dbo.LocBases", "Longitude1");
        }
    }
}
