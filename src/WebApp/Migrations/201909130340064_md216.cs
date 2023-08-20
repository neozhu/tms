namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md216 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SHIPORDERs", "STDTOLL", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.StandardCosts", "STDTOLL", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StandardCosts", "STDTOLL");
            DropColumn("dbo.SHIPORDERs", "STDTOLL");
        }
    }
}
