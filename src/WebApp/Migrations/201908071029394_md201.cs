namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md201 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ORDERDETAILs", "COST5", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ORDERDETAILs", "COST6", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ORDERDETAILs", "FLOOR", c => c.Int(nullable: false));
            AddColumn("dbo.ORDERs", "FLOOR", c => c.Int(nullable: false));
            AddColumn("dbo.ORDERs", "TOTALCOST3", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ORDERs", "TOTALCOST4", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ORDERs", "TOTALCOST5", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ORDERs", "TOTALCOST6", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ORDERs", "TOTALCOST6");
            DropColumn("dbo.ORDERs", "TOTALCOST5");
            DropColumn("dbo.ORDERs", "TOTALCOST4");
            DropColumn("dbo.ORDERs", "TOTALCOST3");
            DropColumn("dbo.ORDERs", "FLOOR");
            DropColumn("dbo.ORDERDETAILs", "FLOOR");
            DropColumn("dbo.ORDERDETAILs", "COST6");
            DropColumn("dbo.ORDERDETAILs", "COST5");
        }
    }
}
