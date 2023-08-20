namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md1007 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LocBases", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 8));
            AlterColumn("dbo.LocBases", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 8));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LocBases", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.LocBases", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
