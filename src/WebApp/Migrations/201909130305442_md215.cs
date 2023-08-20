namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md215 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SHIPORDERs", "TOTALSERVICECOST", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SHIPORDERs", "TOTALSERVICECOST");
        }
    }
}
